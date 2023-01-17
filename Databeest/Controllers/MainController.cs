using Databeest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Databeest.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using System.Security.Claims;
using TaskStatus = Databeest.Models.TaskStatus;
using Task = Databeest.Models.Task;

namespace Databeest.Controllers
{
    [Authorize(Policy = "User")]
    public class MainController : Controller
    {
        // MS generated
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        //

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Virus()
        {
            TaskDB taskDB = new TaskDB();
            User user = GetAuthUser();
            Task task = taskDB.SelectUserTask(user, "Virus");

            return View(task);
        }

        public IActionResult Mailbox()
        {
            return PartialView("Mailbox");
        }

        public IActionResult Photogram()
        {
            TaskDB taskDB = new TaskDB();
            User user = GetAuthUser();
            Task task = taskDB.SelectUserTask(user, "Photogram");

            return View(task);
        }

        public IActionResult Interwebs()
        {
            TaskDB taskDB = new TaskDB();
            User user = GetAuthUser();
            Task task = taskDB.SelectUserTask(user, "WiFi");

            // If wifi is connected (either public or private) go to virus page, otherwise, no wifi
            if (task.Status != TaskStatus.NotStarted)
                return Redirect("/Main/Virus");
            else
                return Redirect("/Main/NoWifi");
        }

        public IActionResult NoWifi()
        {
            return View();
        }

        public IActionResult FakeGoogle()
        {
            return View();
        }

        [HttpPost]
        [Route("/Main/OverlayGood/{id}")]
        public async Task<IActionResult> OverlayGood(int id)
        {
            TaskDB taskDB = new TaskDB();
            User user = GetAuthUser();

            taskDB.UpdateUserTask(user, id, TaskStatus.Good);
            Task task = taskDB.SelectUserTask(user, id);


            return PartialView(task);
        }

        [HttpPost]
        [Route("/Main/OverlayBad/{id}")]
        public async Task<IActionResult> OverlayBad(int id)
        {
            return PartialView();
        }

        private User GetAuthUser()
        {
            UserDB userDB = new UserDB();

            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            Claim claim = identity.FindFirst("Username");
            User user = userDB.Select(claim.Value);

            return user;
        }

        // MS generated
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //
    }
}