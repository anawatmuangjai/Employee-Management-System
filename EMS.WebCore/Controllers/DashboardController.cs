using System;
using System.Threading.Tasks;
using EMS.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardViewModelService _dashboardViewModelService;

        public DashboardController(IDashboardViewModelService dashboardViewModelService)
        {
            _dashboardViewModelService = dashboardViewModelService;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(string selectedDate,int? shiftId)
        {
            if (string.IsNullOrEmpty(selectedDate))
            {
                selectedDate = DateTime.Today.ToString("yyyy/MM/dd");
            }

            var viewModel = await _dashboardViewModelService.GetDashboardResult(selectedDate, shiftId);
            return View(viewModel);
        }
    }
}
