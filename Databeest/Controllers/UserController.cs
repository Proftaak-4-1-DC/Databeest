﻿using Databeest.Common;
using Databeest.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Task = Databeest.Models.Task;
using TaskStatus = Databeest.Models.TaskStatus;

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
            UserDB userDB = new UserDB();

            ClaimsIdentity? identity = (ClaimsIdentity)User.Identity;
            if (!identity.IsAuthenticated)
                return View();

            Claim claim = identity.FindFirst("Username");
            User user = userDB.Select(claim.Value);

            ViewData["Username"] = user.Username;
            ViewData["Email"] = user.Email;

            TaskDB taskDB = new TaskDB();
            Task task = taskDB.SelectUserTask(user, "Wachtwoord Sterkte");

            return View(task);
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
                    User createdUser = userDB.Create(newUser);

                    if (createdUser.Id == -1)
                    {
                        ViewBag.Message = "Ehm, er klopt iets niet. Ohnee!";
                        return View();
                    }

                    // This is where the first task has been completed: Password strength
                    TaskDB taskDB = new TaskDB();

                    taskDB.CreateUserTasks(createdUser);
                    Task task = taskDB.SelectUserTask(createdUser, "Wachtwoord Sterkte");
                    
                    // Regex check
                    bool strongPassword = newUser.IsStrongPassword();
                    if (strongPassword)
                        task.Status = TaskStatus.Good;
                    else
                        task.Status = TaskStatus.Bad;

                    taskDB.UpdateUserTask(createdUser, task);
                    //

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
