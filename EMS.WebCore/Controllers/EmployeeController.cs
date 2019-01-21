using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeDetailService _employeeDetailService;

        public EmployeeController(
            IEmployeeService employeeService,
            IEmployeeDetailService employeeDetailService)
        {
            _employeeService = employeeService;
            _employeeDetailService = employeeDetailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Register(RegisterEmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var employeeExist = await _employeeService.ExistsAsync(viewModel.EmployeeId);

            if (employeeExist)
            {
                ModelState.AddModelError("Error", "Employee ID already exists.");
                return View(viewModel);
            }

            var employee = new EmployeeModel
            {
                EmployeeId = viewModel.EmployeeId,
                GlobalId = viewModel.GlobalId,
                CardId = viewModel.CardId,
                EmployeeType = viewModel.EmployeeType,
                Title = viewModel.Title,
                TitleThai = viewModel.TitleThai,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                FirstNameThai = viewModel.FirstNameThai,
                LastNameThai = viewModel.LastNameThai,
                Gender = viewModel.Gender,
                Height = viewModel.Height,
                Hand = viewModel.Hand,
                BirthDate = viewModel.BirthDate,
                HireType = viewModel.HireType,
                HireDate = viewModel.HireDate,
                AvailableFlag = true,
                ChangedDate = DateTime.Now,
            };

            await _employeeService.AddAsync(employee);

            return RedirectToAction(nameof(EmployeeList));
        }

        [HttpGet]
        [HttpPost]
        [Authorize(Roles = "Administrator,Member")]
        public async Task<IActionResult> EmployeeList(EmployeeFilter filterModel)
        {
            var viewModel = new EmployeeViewModel();

            viewModel.Departments = await _employeeDetailService.GetDepartments();
            viewModel.Shifts = await _employeeDetailService.GetShifts();
            viewModel.Positions = await _employeeDetailService.GetPositions();
            viewModel.JobLevels = await _employeeDetailService.GetLevels();

            if (filterModel.AvailableFlag == null)
            {
                filterModel.AvailableFlag = true;
            }

            if (filterModel.DepartmentId.HasValue)
            {
                viewModel.Sections = await _employeeDetailService.GetSectionsByDepartmentId(filterModel.DepartmentId.Value);
            }

            if (filterModel.SectionId.HasValue)
            {
                viewModel.JobFunctions = await _employeeDetailService.GetJobFunctionsBySectionId(filterModel.SectionId.Value);
            }

            var employees = await _employeeService.GetAsync(filterModel);

            if (employees != null)
            {
                viewModel.Employees = employees;
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