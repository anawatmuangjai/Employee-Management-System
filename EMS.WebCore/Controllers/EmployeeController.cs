using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeListService _employeeListService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeListService employeeListService)
        {
            _employeeService = employeeService;
            _employeeListService = employeeListService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
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
    }
}