using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityUser iUser = new IdentityUser
                {
                    Email = model.Email,
                    UserName=model.Email
                };
                IdentityResult result=await _userManager.CreateAsync(iUser, model.Password);
                if(result.Succeeded)
                    return Redirect("/");
            };
            return View(model);
        }
    }
}
