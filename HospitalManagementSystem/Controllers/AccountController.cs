using HospitalManagementSystem.Entity.Security;
using HospitalManagementSystem.Entity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;     

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Employee");
                }
                ModelState.AddModelError(string.Empty, "Invalid credentials");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ListUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
                ApplicationUser user = new()
                {
                    UserName = model.UserName,
                    Email = model.UserName,
                    IsActive = model.IsActive,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) 
                {
                    return RedirectToAction(nameof(Login));
                }

                foreach (var err in result.Errors) 
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(Logout));
                }
                {
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                }
                
            }
            return View(model);
        }
    }
}
