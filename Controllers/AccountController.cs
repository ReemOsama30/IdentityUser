using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user_Identity.Models;
using user_Identity.viewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly context _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, context context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult register()
        {
            return View("register");
        }

        [HttpGet]
        public IActionResult login()
        {
            return View("login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(loginViewModel uservm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = await _userManager.FindByNameAsync(uservm.userName);

                if (applicationUser != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(applicationUser, uservm.password);

                    if (found)
                    {
                        await _signInManager.SignInAsync(applicationUser, uservm.RememberMe);
                        return Content("hiii");
                    }
                }
                ModelState.AddModelError("", "Invalid username or password");
            }

            return View("login");
        }

        [HttpPost]
        public async Task<IActionResult> register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    UserName = model.userName,
                    address = model.address,
                };

                IdentityResult result = await _userManager.CreateAsync(applicationUser, model.password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, "User");
                    await _signInManager.SignInAsync(applicationUser, false);
                   // return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("register", model);
        }

        public async Task<IActionResult> signOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<ApplicationUser> users = _context.Users.ToList();
            return View(users);
        }
    }
}
