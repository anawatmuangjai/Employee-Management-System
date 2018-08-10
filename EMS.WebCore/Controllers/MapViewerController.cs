using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class MapViewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Area()
        {
            return View();
        }

        public IActionResult Line()
        {
            return View();
        }

        public IActionResult Zone()
        {
            return View();
        }
    }
}