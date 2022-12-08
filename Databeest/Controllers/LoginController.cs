using Databeest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Databeest.Controllers
{
    public class LoginController : Controller
    {
        // MS generated
        private readonly ILogger<MainController> _logger;

        public LoginController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        //

        /************************************************************************/
        /* Login                                                                */
        /************************************************************************/
        public IActionResult Login()
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
