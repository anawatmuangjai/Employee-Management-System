using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.WebCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeListService _employeeListService;
        private readonly IEmployeeRegisterService _registerService;

        public EmployeeController(IEmployeeListService employeeListService,
            IEmployeeRegisterService registerService)
        {
            _employeeListService = employeeListService;
            _registerService = registerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var viewModel = await _registerService.GetRegisterEmployeeViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _registerService.CreateEmployee(model);

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