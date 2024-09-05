using App_Application.Concretes;
using App_Application.Concretes.VMs;
using App_Domain.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace App_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly Units _units;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, Units units)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _units = units;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region Register

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var identityResult = await _userManager.CreateAsync(user, model.Password);
                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                        foreach (var item in identityResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                }
            }
            return View(model);
        }

        #endregion

        #region Login

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                if (identityResult.Succeeded)
                {
                    TempData["success"] = "Giriş işlemi başarıyla güncellendi.";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Email or Password is wrong.");
            }
            return View(model);
        }
        #endregion

        #region LogOut

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["success"] = "Çıkış işlemi başarıyla güncellendi.";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Profile

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            User currentUser = await _userManager.GetUserAsync(User);

            ProfileVM model = new ProfileVM();
            model.ImageUrl = currentUser.ImageUrl;
            model.FirstName = currentUser.FirstName;
            model.LastName = currentUser.LastName;
            model.Description = currentUser.Description;
            model.Email = currentUser.Email;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileVM model, IFormFile? formFile)
        {
            User currentUser = await _userManager.GetUserAsync(User);
             
            //foto eklediyse ve işlem başarılıysa silinecek fotonun yolunu verdim
            string willDeletePathIfResultSucceed = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{currentUser.ImageUrl}");

            string imgName = currentUser.ImageUrl;
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
                currentUser.ImageUrl = imgName;
                currentUser.Email = model.Email;
                currentUser.UserName = model.Email;
                currentUser.FirstName = model.FirstName;
                currentUser.LastName = model.LastName;
                currentUser.Description = model.Description;

                var identityResult = await _userManager.UpdateAsync(currentUser);
                if (identityResult.Succeeded)
                { 
                    if (System.IO.File.Exists(willDeletePathIfResultSucceed) && currentUser.ImageUrl!=imgName)
                    {
                        System.IO.File.Delete(willDeletePathIfResultSucceed); 
                    }
                    TempData["success"] = "Bilgileriniz başarıyla güncellendi.";
                    model.ImageUrl = currentUser.ImageUrl;
                    return View(model);
                }
            }
            model.ImageUrl = currentUser.ImageUrl; 
            TempData["error"] = "Güncelleme esnasında bir sorunla karşılaşıldı."; 
            return View(model);
        }


        #endregion

    }
}
