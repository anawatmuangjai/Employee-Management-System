using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class MonitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MapViewer()
        {
            return View();
        }

        public IActionResult Layout()
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