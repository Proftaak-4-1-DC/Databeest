using Databeest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Databeest.Common;

namespace Databeest.Controllers
{
    public class MainController : Controller
    {
        // MS generated
        private readonly ILogger<MainController> _logger;
        //private SqlManager SqlManager  = new SqlManager();

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        //

        /************************************************************************/
        /* Index                                                                */
        /************************************************************************/
        public IActionResult Index()
        {
            return View("Partials/_Virus");
            return View("Partials/_Index");
            //SqlManager.OpenConnection();
        }

        [HttpPost]
        public IActionResult IndexPost()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Register()
        {
            return PartialView("Partials/_Register");
        }

        //[HttpPost]
        //public IActionResult RegisterPost(User user)
        //{
        //   user = new User(user.Username, user.Password);
        //   UserDB.Create(user);
        //   return View();
        //}

        public IActionResult Login()
        {
            return PartialView("Partials/_Login");
        }

        public IActionResult Policy()
        {
            return PartialView("Partials/_Policy");
        }

        public IActionResult Virus()
        {
            return PartialView("_Virus");
        }

        public IActionResult Mailbox()
        {
            return PartialView("_Mailbox");
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