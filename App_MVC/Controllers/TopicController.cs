using App_Application.Concretes;
using App_Application.Concretes.VMs;
using App_Domain.Concretes;
using App_Domain.Concretes.Composites;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App_MVC.Controllers
{
    public class TopicController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly Units _units;

        public TopicController(SignInManager<User> signInManager, UserManager<User> userManager, Units units)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _units = units;
        }

        public async Task<IActionResult> Index()
        {
            IList<TopicListVM> topicListVMs = new List<TopicListVM>();

            User currentUser = await _userManager.GetUserAsync(User);

            foreach (var item in _units._topic.GetAll().ToList())
            {
                topicListVMs.Add(new TopicListVM()
                {
                    Topic = item,
                    IsSelected = _units._userTopic.GetAny(x => x.TopicId == item.Id && x.UserId == currentUser.Id)
                });
            }


            return View(topicListVMs);
        }

        public async Task<IActionResult> AddRemoveTopic(int topicId, bool isSelected)
        {
            User currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (isSelected)
                {
                    UserTopic onDeleting = _units._userTopic.GetById(currentUser.Id, topicId);
                    _units._userTopic.Delete(onDeleting, true);
                }
                else
                {
                    _units._userTopic.Create(new UserTopic()
                    {
                        TopicId = topicId,
                        UserId = currentUser.Id
                    });
                }
            }
            return RedirectToAction("Index", "Topic");
        }

        public async Task<IActionResult> AddRemoveTopic2(int topicId)
        {
            User currentUser = await _userManager.GetUserAsync(User);
            bool isSelected = _units._userTopic.GetAny(x => x.TopicId == topicId && x.UserId == currentUser.Id);

            if (currentUser != null)
            {
                if (isSelected)
                {
                    UserTopic onDeleting = _units._userTopic.GetById(currentUser.Id, topicId);
                    _units._userTopic.Delete(onDeleting, true);
                }
                else
                {
                    _units._userTopic.Create(new UserTopic()
                    {
                        TopicId = topicId,
                        UserId = currentUser.Id
                    });
                }
            }
            bool _isSelectedJson = _units._userTopic.GetAny(x => x.TopicId == topicId && x.UserId == currentUser.Id);
            return Json(_isSelectedJson);
        }

    }
}
