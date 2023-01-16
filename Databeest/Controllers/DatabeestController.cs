using Microsoft.AspNetCore.Mvc;

namespace Databeest.Controllers
{
    public class DatabeestController : Controller
    {
        public IActionResult PositiveDatabeast()
        {
            return PartialView("Partials/_PositiveDatabeast");
        }

        public IActionResult NegativeDatabeast()
        {
            return PartialView("Partials/_NegativeDatabeast");
        }

        [HttpPost]
        public IActionResult PostDatabeast()
        {
            // Post request met task status/points


            return View();
        }
    }
}
