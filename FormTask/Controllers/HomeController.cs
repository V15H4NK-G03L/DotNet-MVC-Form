using FormTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Verification(string Email, string Password, string Number)
        {
            IndexViewModel verify = new IndexViewModel();
            verify.Email = Email;
            verify.Password = Password;
            verify.Number = Number;
            bool checknum = int.TryParse(verify.Number, out int a);
            if (checknum == true)
            {
                if (verify.Number.Length == 10)
                {
                    //verify.Number ="Phone Number Invalid!";
                    return View();
                }
                else
                {
                    return Content("Enter exactly 10 digits. Try Again!");
                }

            }
            else
            {
                return Content("Only numbers allowed. Try Again!");
            }

            //return View(verify);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
