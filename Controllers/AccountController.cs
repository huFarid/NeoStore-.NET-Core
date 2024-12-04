using Microsoft.AspNetCore.Mvc;

namespace NeoStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        
        public IActionResult RegisterConfimed()
        {
            return View();
        }
    }
}
