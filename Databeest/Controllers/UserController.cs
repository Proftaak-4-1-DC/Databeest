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

                    List<Claim> claims = new List<Claim>
                    {
                        new Claim("Username", newUser.Username)
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity),
                        new AuthenticationProperties()
                    );

                    _logger.LogInformation($"User {newUser.Username} logged in");

                    return RedirectToAction(nameof(MainController.Index));
                }
                return View();
            } else
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
