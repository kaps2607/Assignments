using Clinical_Appointment_System.Constants;
using Clinical_Appointment_System.Models;
using Clinical_Appointment_System.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clinical_Appointment_System.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManger;
        readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<User> manager, SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = manager;
            _signInManger = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            ModelState.Remove("Role");
            if (ModelState.IsValid)
            {
                var createdUser = new User
                {
                    UserName = user.Email,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                var result = await _userManager.CreateAsync(createdUser, user.Password);
                if (result.Succeeded)
                {
                    //if (!await _roleManager.RoleExistsAsync(UserRole.Patient))
                    //{
                    //    await _roleManager.CreateAsync(new IdentityRole(UserRole.Patient)); // Ensure role exists
                    //}
                    await _userManager.AddToRoleAsync(createdUser, UserRole.Patient);
                    
                    return RedirectToAction("LogIn");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManger.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Appointment");
                }
                ModelState.AddModelError("", "LoginFailed");
            }
            return View(loginModel);
        }



        public async Task<IActionResult> LogOut()
        {
            await _signInManger.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
