using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using  WebStore.DomainEntities.Entities;

namespace WebStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> Usermanager, SignInManager<User> SignInManager)
        {
            _userManager = Usermanager;
            _signInManager = SignInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegistrationUserViewModel());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = new User()
            {
                UserName = model.UserName
            };
            var regResult = await _userManager.CreateAsync(user, model.Password);
            if (regResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var regResultError in regResult.Errors)
                {
                    ModelState.AddModelError("", regResultError.Description);
                }
                return View(model);
            }
        }
    }
}