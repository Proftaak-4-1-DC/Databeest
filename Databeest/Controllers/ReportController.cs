using Databeest.Common;
using Databeest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task = Databeest.Models.Task;
using TaskStatus = Databeest.Models.TaskStatus;

namespace Databeest.Controllers
{
    [Authorize(Policy = "User")]
    public class ReportController : Controller
    {
        public IActionResult Eindscore()
        {
            Dictionary<string, int> dict = calculateScores();
            ViewData["scores"] = dict;

            int score = 0;
            foreach (var item in dict)
            {
                score += item.Value;
                ViewData[item.Key] = item.Value;
            }

            ViewData["totalScore"] = score;

            return View();
        }

        private Dictionary<string, int> calculateScores()
        {
            User user = GetAuthUser();
            TaskDB taskDB = new TaskDB();

            // 1 t/m 8
            Dictionary<string, int> scores = new Dictionary<string, int>();
            for (int i = 1; i < 9; i++)
            {
                Task task = taskDB.SelectUserTask(user, i);
                scores.Add(task.Name, task.Status == TaskStatus.Good ? (int)task.Points : 0);
            }

            return scores;
        }

        private User GetAuthUser()
        {
            UserDB userDB = new UserDB();

            ClaimsIdentity? identity = (ClaimsIdentity)User.Identity;

            Claim claim = identity.FindFirst("Username");
            User user = userDB.Select(claim.Value);

            return user;
        }
    }
}
