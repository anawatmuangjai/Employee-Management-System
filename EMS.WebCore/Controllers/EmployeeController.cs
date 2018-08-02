using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.WebCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeListService _employeeListService;
        private readonly IDepartmentService _departmentService;
        private readonly ISectionService _sectionService;
        private readonly IJobService _jobService;
        private readonly IEmployeeLevelService _levelService;

        public EmployeeController(IEmployeeService employeeService,
            IEmployeeListService employeeListService,
            IDepartmentService departmentService,
            ISectionService sectionService,
            IJobService jobService,
            IEmployeeLevelService levelService)
        {
            _employeeService = employeeService;
            _employeeListService = employeeListService;
            _departmentService = departmentService;
            _sectionService = sectionService;
            _jobService = jobService;
            _levelService = levelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var viewModel = new RegisterEmployeeViewModel();

            viewModel.Departments = await GetDepartments();
            viewModel.Sections = await GetSections();
            viewModel.JobTitles = await GetJobTitles();
            viewModel.Levels = await GetLevels();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new EmployeeModel
                {
                    EmployeeId = model.EmployeeId,
                    GlobalId = model.GlobalId,
                    CardId = model.CardId,
                    EmployeeType = model.EmployeeType,
                    Title = model.Title,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FirstNameThai = model.FirstNameThai,
                    LastNameThai = model.LastNameThai,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    HireDate = model.HireDate,
                    AvailableFlag = true,
                    ChangedDate = DateTime.Now,
                };

                employee = await _employeeService.AddAsync(employee);

                return RedirectToAction(nameof(EmployeeList));
            }

            return View();
        }

        public async Task<IActionResult> EmployeeList()
        {
            var employees = await _employeeListService.GetAllAsync();

            var viewModel = new EmployeeViewModel
            {
                Employees = employees
            };

            return View(viewModel);
        }

        public async Task<IEnumerable<SelectListItem>> GetJobTitles()
        {
            var jobTitles = await _jobService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var job in jobTitles)
            {
                item.Add(new SelectListItem()
                {
                    Value = job.JobTitleId.ToString(),
                    Text = job.JobTitle
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetLevels()
        {
            var levels = await _levelService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var level in levels)
            {
                item.Add(new SelectListItem()
                {
                    Value = level.LevelId.ToString(),
                    Text = level.LevelName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetDepartments()
        {
            var departments = await _departmentService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var department in departments)
            {
                item.Add(new SelectListItem()
                {
                    Value = department.DepartmentId.ToString(),
                    Text = department.DepartmentName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetSections()
        {
            var sections = await _sectionService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "", Selected = true}
            };

            foreach (var section in sections)
            {
                item.Add(new SelectListItem()
                {
                    Value = section.SectionId.ToString(),
                    Text = section.SectionName
                });
            }

            return item;
        }
    }
}