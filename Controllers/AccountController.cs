using Microsoft.AspNetCore.Mvc;
using NeoStore.Models;

namespace NeoStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
           

            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountViewModel account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            return View();
        }
    }
}
