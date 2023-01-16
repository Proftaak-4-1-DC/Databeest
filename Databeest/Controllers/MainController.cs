using Databeest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Databeest.Common;
using Microsoft.AspNetCore.Authorization;

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
            return View();
        }

        public IActionResult Mailbox()
        {
            return PartialView("Mailbox");
        }

        public IActionResult Photogram()
        {
            return View();
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