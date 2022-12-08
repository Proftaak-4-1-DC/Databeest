using Databeest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Databeest.Controllers
{
    public class MainController : Controller
    {
        // MS generated
        private readonly ILogger<MainController> _logger;

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