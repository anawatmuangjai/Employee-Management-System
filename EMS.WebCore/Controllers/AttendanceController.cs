using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.ViewModels.Attendance;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(
            IEmployeeService employeeService,
            IAttendanceService attendanceService)
        {
            _employeeService = employeeService;
            _attendanceService = attendanceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ActiveWork()
        {
            var attendances = await _attendanceService.GetActiveAsync();

            var viewModel = new AttendanceViewModel
            {
                Attendances = attendances
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Absent()
        {
            var attendances = await _attendanceService.GetAbsentAsync();

            var viewModel = new AttendanceViewModel
            {
                Attendances = attendances
            };

            return View(viewModel);
        }

        public async Task<IActionResult> History(string employeeId)
        {
            var startDate = DateTime.Today.AddDays(-10).ToString("yyyy/MM/dd");
            var endDate = DateTime.Today.ToString("yyyy/Mm/dd");
            var viewModel = new AttendanceHistoryViewModel();

            if (!String.IsNullOrEmpty(employeeId))
            {
                var employee = await _employeeService.GetByEmployeeIdAsync(employeeId);
                var attendances = await _attendanceService.GetHistoryAsync(employeeId, startDate, endDate);

                viewModel.Employee = employee;
                viewModel.Attendances = attendances;
            }

            return View(viewModel);
        }
    }
}