using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.Interfaces;
using EMS.WebCore.Models;
using EMS.WebCore.ViewModels.Attendance;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeImageService _employeeImageService;
        private readonly IAttendanceService _attendanceService;

        private readonly IAttendanceViewModelService _attendanceViewModelService;

        public AttendanceController(
            IEmployeeService employeeService,
            IEmployeeImageService employeeImageService,
            IAttendanceService attendanceService,
            IAttendanceViewModelService attendanceViewModelService)
        {
            _employeeService = employeeService;
            _employeeImageService = employeeImageService;
            _attendanceService = attendanceService;
            _attendanceViewModelService = attendanceViewModelService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ActiveWork(string employeeId)
        {
            var filter = new AttendanceFilterModel
            {
                EmployeeId = employeeId
            };

            var viewModel = await _attendanceViewModelService.GetActive();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Absent()
        {
            var attendances = await _attendanceService.GetAbsentAsync();

            var viewModel = new AttendanceViewModel
            {
                Attendances = attendances
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> History(string employeeId, string startDate, string endDate)
        {
            var viewModel = new AttendanceViewModel();

            if (String.IsNullOrEmpty(startDate))
                startDate = DateTime.Today.AddDays(-10).ToString("yyyy/MM/dd");

            if (String.IsNullOrEmpty(endDate))
                endDate = DateTime.Today.ToString("yyyy/MM/dd");

            var image = await _employeeImageService.GetByEmployeeId(employeeId);

            if (image != null)
            {
                var imageBase64Data = Convert.ToBase64String(image.Images);
                viewModel.ProfileImage = string.Format("data:image/png;base64,{0}", imageBase64Data);
            }

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