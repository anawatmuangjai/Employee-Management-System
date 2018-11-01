using System;
using System.Linq;
using System.Text;
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
        public async Task<IActionResult> Index(string selectedDate, int? shiftId)
        {
            if (string.IsNullOrEmpty(selectedDate))
            {
                selectedDate = DateTime.Today.ToString("yyyy/MM/dd");
            }

            var viewModel = await _dashboardViewModelService.GetDashboardResult(selectedDate, shiftId);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Download()
        {
            var date = DateTime.Today.ToString("yyyy/MM/dd");

            var employeeRecords = await _dashboardViewModelService.GetEmployeeLeave(date);

            // Build the file content
            var csv = new StringBuilder();
            var header = "Type,Employee ID,Level,Shift,Department,Section,Position,Job Function,Route,Bus Station";
            csv.AppendLine(header);

            foreach (var e in employeeRecords)
            {
                var newLine = $"{e.EmployeeType},{e.EmployeeId},{e.LevelCode},{e.ShiftName}," +
                    $"{e.DepartmentCode},{e.SectionName},{e.JobTitle},{e.FunctionName},{e.RouteName},{e.BusStationName}";

                csv.AppendLine(newLine);
            }

            var data = Encoding.UTF8.GetBytes(csv.ToString());
            var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
            return File(result, "application/csv", "EmployeeLeave.csv");
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTransport()
        {
            var date = DateTime.Today.ToString("yyyy/MM/dd");

            var employeeRecords = await _dashboardViewModelService.GetEmployeeLeave(date);

            // Build the file content
            var csv = new StringBuilder();
            var header = "EmployeeID,OT,Car";
            csv.AppendLine(header);

            foreach (var e in employeeRecords)
            {
                var newLine = $"{e.EmployeeId},1,1";

                csv.AppendLine(newLine);
            }

            var data = Encoding.UTF8.GetBytes(csv.ToString());
            var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
            return File(result, "application/csv", "ChangeTransport.csv");
        }
    }
}
