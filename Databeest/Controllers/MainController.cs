﻿using Databeest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Databeest.Common;

namespace Databeest.Controllers
{
    public class MainController : Controller
    {
        // MS generated
        private readonly ILogger<MainController> _logger;
        private SqlManager SqlManager  = new SqlManager();

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
            SqlManager.OpenConnection();

            return View();
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