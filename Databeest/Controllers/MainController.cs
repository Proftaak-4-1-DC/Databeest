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

        private void PrepView()
        {
            User user = GetAuthUser();
            ViewData["Username"] = user.Username;
            ViewData["Email"] = user.Email;
            ViewData["Wifi"] = HasWifi();
            
            
        }

        public IActionResult Index()
        {
            if (TasksDone())
                return Redirect("/Report/Eindscore");

            PrepView();

            return View();
        }

        public IActionResult Mailbox()
        {
            if (TasksDone())
                Redirect("/Report/Eindscore");

            if (HasWifi() == "nowifi")
                return Redirect("/Main/NoWifi");

            PrepView();

            User user = GetAuthUser();

            TaskDB taskDB = new TaskDB();
            Task[] tasks = new Task[4];
            tasks[0] = taskDB.SelectUserTask(user, 1);
            tasks[1] = taskDB.SelectUserTask(user, 6);
            tasks[2] = taskDB.SelectUserTask(user, 8);
            tasks[3] = taskDB.SelectUserTask(user, 7);

            return View(tasks);
        }

        public IActionResult Photogram()
        {
            if (TasksDone())
                Redirect("/Report/Eindscore");

            if (HasWifi() == "nowifi")
                return Redirect("/Main/NoWifi");

            PrepView();
            User user = GetAuthUser();

            TaskDB taskDB = new TaskDB();
            Task task = taskDB.SelectUserTask(user, "Photogram");

            return View(task);
        }

        public IActionResult Interwebs()
        {
            if (TasksDone())
                Redirect("/Report/Eindscore");

            PrepView();
            User user = GetAuthUser();

            if (HasWifi() == "nowifi")
                return Redirect("/Main/NoWifi");

            TaskDB taskDB = new TaskDB();
            Task virusTask = taskDB.SelectUserTask(user, "Virus");

            if (virusTask.Status != TaskStatus.NotStarted)
                return Redirect("/Main/OverlayDone");
            return Redirect("/Main/Virus");
        }

        public IActionResult Virus()
        {
            if (TasksDone())
                Redirect("/Report/Eindscore");

            if (HasWifi() == "nowifi")
                return Redirect("/Main/NoWifi");

            PrepView();
            User user = GetAuthUser();

            TaskDB taskDB = new TaskDB();
            Task task = taskDB.SelectUserTask(user, "Virus");

            return View(task);
        }

        public IActionResult NoWifi()
        {
            if (TasksDone())
                Redirect("/Report/Eindscore");

            PrepView();

            return View();
        }

        public IActionResult FakeGoogle()
        {
            if (TasksDone())
                Redirect("/Report/Eindscore");

            if (HasWifi() == "nowifi")
                return Redirect("/Main/NoWifi");

            PrepView();

            return View();
        }

        public IActionResult OverlayDone()
        {
            if (TasksDone())
                Redirect("/Report/Eindscore");

            PrepView();

            return View();
        }

        [HttpPost]
        [Route("/Main/OverlayGood/{id}")]
        public async Task<IActionResult> OverlayGood(int id)
        {
            PrepView();
            User user = GetAuthUser();

            TaskDB taskDB = new TaskDB();

            Task task = taskDB.SelectUserTask(user, id);
            if (task.IsShown)
            {
                StatusCodeResult result = new StatusCodeResult(418);
                return result;
            }

            taskDB.UpdateUserTask(user, id, TaskStatus.Good);
            task = taskDB.SelectUserTask(user, id);

            taskDB.UpdateUserTask(user, id, true);

            return PartialView(task);
        }

        [HttpPost]
        [Route("/Main/OverlayBad/{id}")]
        public async Task<IActionResult> OverlayBad(int id)
        {
            PrepView();
            User user = GetAuthUser();

            TaskDB taskDB = new TaskDB();

            Task task = taskDB.SelectUserTask(user, id);
            if (task.IsShown)
                return Redirect(task.ReturnUrl);

            taskDB.UpdateUserTask(user, id, TaskStatus.Bad);
            task = taskDB.SelectUserTask(user, id);

            taskDB.UpdateUserTask(user, id, true);

            return PartialView(task);
        }


        private User GetAuthUser()
        {
            UserDB userDB = new UserDB();

            ClaimsIdentity? identity = (ClaimsIdentity)User.Identity;

            Claim claim = identity.FindFirst("Username");
            User user = userDB.Select(claim.Value);

            return user;
        }

        private string HasWifi()
        {
            User user = GetAuthUser();
            TaskDB taskDB = new TaskDB();

            Task task = taskDB.SelectUserTask(user, 3);
            if (task.Status == TaskStatus.NotStarted)
                return "nowifi";
            else if (task.Status == TaskStatus.Bad)
                return "free";
            else
                return "notfree";
        }

        private bool TasksDone()
        {
            User user = GetAuthUser();
            TaskDB taskDB = new TaskDB();

            // 1 t/m 8
            bool allTasksDone = true;
            for (int i = 1; i < 9; i++)
            {
                Task task = taskDB.SelectUserTask(user, i);
                if (task.Status == TaskStatus.NotStarted)
                    allTasksDone = false;
            }

            return allTasksDone;
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