using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.Interfaces;
using EMS.WebCore.Models;
using EMS.WebCore.ViewModels.Attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.WebCore.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeImageService _employeeImageService;
        private readonly IEmployeeDetailService _employeeDetailService;
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(
            IEmployeeService employeeService,
            IEmployeeImageService employeeImageService,
            IEmployeeDetailService employeeDetailService,
            IAttendanceService attendanceService)
        {
            _employeeService = employeeService;
            _employeeImageService = employeeImageService;
            _employeeDetailService = employeeDetailService;
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ActiveWork(AttendanceFilter filterModel)
        {
            var viewModel = new AttendanceViewModel();

            if (string.IsNullOrEmpty(filterModel.AttendanceDate))
            {
                filterModel.AttendanceDate = DateTime.Today.ToString("yyyy/MM/dd");
            }

            viewModel.Attendances = await _attendanceService.GetActiveAsync(filterModel);
            viewModel.Departments = await _employeeDetailService.GetDepartments();
            viewModel.Shifts = await _employeeDetailService.GetShifts();
            viewModel.Positions = await _employeeDetailService.GetPositions();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Absent(AttendanceFilter filterModel)
        {
            var viewModel = new AttendanceViewModel();

            if (string.IsNullOrEmpty(filterModel.AttendanceDate))
            {
                filterModel.AttendanceDate = DateTime.Today.ToString("yyyy/MM/dd");
            }

            viewModel.Attendances = await _attendanceService.GetAbsentAsync(filterModel);
            viewModel.Departments = await _employeeDetailService.GetDepartments();
            viewModel.Shifts = await _employeeDetailService.GetShifts();
            viewModel.Positions = await _employeeDetailService.GetPositions();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Late(AttendanceFilter filterModel)
        {
            var viewModel = new AttendanceViewModel();

            if (string.IsNullOrEmpty(filterModel.AttendanceDate))
            {
                filterModel.AttendanceDate = DateTime.Today.ToString("yyyy/MM/dd");
                filterModel.IsLate = true;
            }

            viewModel.Attendances = await _attendanceService.GetActiveAsync(filterModel);
            viewModel.Departments = await _employeeDetailService.GetDepartments();
            viewModel.Shifts = await _employeeDetailService.GetShifts();
            viewModel.Positions = await _employeeDetailService.GetPositions();

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
                var employee = await _employeeService.GetByEmployeeIdWithDetailAsync(employeeId);
                var attendances = await _attendanceService.GetHistoryAsync(employeeId, startDate, endDate);

                viewModel.Employee = employee;
                viewModel.Attendances = attendances;
            }

            return View(viewModel);
        }

        public async Task<JsonResult> GetSectionByDepartmentId(int departmentId)
        {
            var items = await _employeeDetailService.GetSectionsByDepartmentId(departmentId);

            return Json(new SelectList(items, "Value", "Text"));
        }

        public async Task<JsonResult> GetJobFunctionBySectionId(int sectionId)
        {
            var items = await _employeeDetailService.GetJobFunctionsBySectionId(sectionId);

            return Json(new SelectList(items, "Value", "Text"));
        }
    }
}