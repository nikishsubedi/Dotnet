using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {

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
    }
}
