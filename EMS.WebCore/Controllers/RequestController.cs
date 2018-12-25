using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OverTimeReport()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OverTimeRequest()
        {
            return View();
        }
    }
}