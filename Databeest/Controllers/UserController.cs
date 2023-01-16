using Databeest.Common;
using Databeest.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Databeest.Controllers
{
    public class UserController : Controller
    {
        // MS generated
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        //

        public IActionResult Policy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            UserDB userDB = new UserDB();

            if (!userDB.Exists(user))
            {
                ViewBag.Message = "Gebruiker bestaat niet!";
                return View();
            }

            User dbUser = userDB.Select(user);
            if (dbUser.Password != user.Password && dbUser.Username == user.Username)
            {
                ViewBag.Message = "Wachtwoord komt niet overeen!";
                return View();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim("Username", user.Username)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties()
            );

            return Redirect("/Main/Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                UserDB userDB = new UserDB();
                User newUser = new User(user.Username, user.Password);

                if (userDB.Exists(newUser))
                    ViewBag.Message = "Gebruikersnaam bestaat al!";
                else
                {
                    userDB.Create(newUser);

                    return Redirect("/User/Login");
                }
                return View();
            } else
            {
                ViewBag.Message = "Ehm, er klopt iets niet. Ohnee!";
                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/User/Login");
        }
    }
}
