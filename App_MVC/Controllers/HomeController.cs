using App_Application.Concretes;
using App_Application.Concretes.VMs;
using App_Domain.Concretes;
using App_Domain.Concretes.Composites;
using App_Domain.Enums;
using App_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace App_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager; 
        private readonly ILogger<HomeController> _logger;
        private readonly Units _units;

        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, UserManager<User> userManager, Units units)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _units = units;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _userManager.GetUserAsync(User);

            if (currentUser is not null)
            { 
                IList<CreateStoryVM> storyVMs = _units._story.GetAllAsStoryVM(currentUser, _units).ToList();
                HomeStoryVM homeStoryVM = new HomeStoryVM();
                homeStoryVM.StoryVMs = storyVMs;
                homeStoryVM.SelectForTopicId = _units._operations.FillSelectListItem<Topic>(_units._topic.GetAll(), x => x.TopicName, x => x.Id.ToString());
                homeStoryVM.Topics = _units._topic.GetAll().ToList(); 

                return View(homeStoryVM);
            }
            return View(); 
        }
         
        public IActionResult AboutUs()
        { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<IActionResult> Like(int storyId, string userId, string goAction, string goController)
        //{
        //    _units._likeUserStory.LikeAStory(storyId, userId, out int likeCount);
        //    _units._story.UpdateStoryLikeCount(storyId, likeCount);

        //    return RedirectToAction(goAction, goController, new { storyId = storyId });
        //}

        public async Task<IActionResult> Like2(int storyId, string userId, string goAction, string goController)
        {
            _units._likeUserStory.LikeAStory(storyId, userId, out int likeCount);
            _units._story.UpdateStoryLikeCount(storyId, likeCount);
            bool isUserLiked=_units._likeUserStory.IsUserLiked(storyId,userId);
            string like = JsonConvert.SerializeObject(isUserLiked);
            return Json(like); 
        }

        public async Task<IActionResult> OthersProfile(string userId)
        {
            var otherUser = await _userManager.FindByIdAsync(userId); 
            OthersProfileVM othersProfileVM = _units._user.GetOtherProfileVM(otherUser, _units);

            return View(othersProfileVM);
        }

        public async Task<IActionResult> Search(string searchText, List<int> selectedTopics,string search)
        {
            var currentUser = await _userManager.GetUserAsync(User);
             
            IList<CreateStoryVM> storyVMs = _units._story.Search(search, selectedTopics, currentUser, _units).ToList();

            HomeStoryVM homeStoryVM = new HomeStoryVM();
            homeStoryVM.StoryVMs = storyVMs;
            homeStoryVM.SelectForTopicId = _units._operations.FillSelectListItem<Topic>(_units._topic.GetAll(), x => x.TopicName, x => x.Id.ToString());
            homeStoryVM.Topics = _units._topic.GetAll().ToList();

            return View("Index", storyVMs);
        } 
    }
}
