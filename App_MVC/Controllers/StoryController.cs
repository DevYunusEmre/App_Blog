using App_Application.Concretes;
using App_Application.Concretes.VMs;
using App_Domain.Concretes;
using App_Domain.Concretes.Composites;
using App_Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App_MVC.Controllers
{
    public class StoryController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly Units _units;

        public StoryController(SignInManager<User> signInManager, UserManager<User> userManager, Units units)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _units = units;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            var topics = _units._topic.GetAll();
            var allTopics = _units._operations.FillSelectListItem<Topic>(topics, x => x.TopicName, x => x.Id.ToString());
            CreateStoryVM model = new CreateStoryVM()
            {
                SelectForTopicId = allTopics,
                CurrentUserId = currentUser.Id 
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStoryVM model, IFormFile? formFile)
        {
            //burada current userın ID'sini modele ekledik  
            User currentUser = await _userManager.GetUserAsync(User);
            model.CurrentUserId = currentUser.Id;

            string willDeletePathIfResultSucceed = null;
            string imgName = null;

            Story currentStory = _units._story.GetById(model.Id);
            if (currentStory != null)
            {
                willDeletePathIfResultSucceed = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{currentStory.ImageUrl}");
                imgName = currentStory.ImageUrl;
            }

            if (formFile is not null)
            {
                string imgExtension = Path.GetExtension(formFile.FileName);
                imgName = Guid.NewGuid().ToString() + imgExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imgName}");
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }

            if (ModelState.IsValid)
            {
                if (currentStory is null)
                    currentStory = new Story();

                currentStory.ImageUrl = imgName;
                currentStory.Title = model.Title;
                currentStory.Content = model.Content;
                currentStory.UserId = model.CurrentUserId;

                if (_units._story.Create(currentStory) > 0)
                {
                    //story ile topic composite tablosu ekleniyor...
                    _units._storyTopic.Create(new StoryTopic()
                    {
                        StoryId = currentStory.Id,
                        TopicId = model.TopicId
                    });
                    if (System.IO.File.Exists(willDeletePathIfResultSucceed) && currentUser.ImageUrl != imgName)
                    {
                        System.IO.File.Delete(willDeletePathIfResultSucceed);
                    }
                    model.ImageUrl = currentStory.ImageUrl;

                    return RedirectToAction("Index", "Home");
                }
            }

            if (model.ImageUrl != null)
            {
                model.ImageUrl = currentStory.ImageUrl;
            }

            TempData["error"] = "Güncelleme esnasında bir sorunla karşılaşıldı.";
            return View();
        }


        public async Task<IActionResult> MyStories()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            IList<CreateStoryVM> storyVMs = new List<CreateStoryVM>();
            var stories = _units._story.GetAllFiltered(x => x.UserId == currentUser.Id && x.Status == Status.Created);
            foreach (var item in stories)
            {
                storyVMs.Add(new CreateStoryVM()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    UserName = item.User.Email
                });
            }
            return View(storyVMs);
        }

        public async Task<IActionResult> ReadStory(int storyId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentStory = _units._story.GetById(storyId);
            var selectedUser = await _userManager.FindByIdAsync(currentStory.UserId);

            _units._story.AddStoryViewCount(currentStory);

            ReadStoryVM readStoryVM = _units._story.GetSelectedStoryInfo(selectedUser, currentStory, _units._likeUserStory, currentUser);
            return View(readStoryVM);
        }

        public async Task<IActionResult> Remove(int storyId)
        {
            _units._story.Delete(_units._story.GetById(storyId));
            return RedirectToAction("MyStories");
        }

    }
}
