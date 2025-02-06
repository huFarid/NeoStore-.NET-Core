using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NeoStore.Data.Repositories;
using NeoStore.Models;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace NeoStore.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Register New User

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

            if (_userRepository.HasUserByEmail(account.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "This email adress already exists");

                return View(account);
            }

            var newUser = new User()
            {
                Email = account.Email,
                Password = account.Password,
                IsAdmin = false,
                RegistrationTime = DateTime.Now
            };

            _userRepository.AddUser(newUser);

            return View("RegisterConfirmed", account);
        }
        #endregion


        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public  IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) 
            { return View(loginViewModel); }

            var user = _userRepository.GetUserForLogin(loginViewModel.Email, loginViewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Information is not correct");
                return View(loginViewModel);
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email)

            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = loginViewModel.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");



            //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //var principal = new ClaimsPrincipal(identity);
            //var properties = new AuthenticationProperties
            //{
            //    IsPersistent = loginViewModel.RememberMe
            //};


            //HttpContext.SignInAsync(principal, properties);
            //return Redirect("/");
        }

        #endregion

        #region Logout

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        #endregion
    }
}
