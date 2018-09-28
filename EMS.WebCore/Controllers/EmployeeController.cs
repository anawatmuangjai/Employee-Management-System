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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EmployeeController : Controller
    {
        private readonly IAccountService _registerService;
        private readonly IEmployeeViewModelService _employeeViewModelService;

        public EmployeeController(IAccountService registerService,
            IEmployeeViewModelService profileService)
        {
            _registerService = registerService;
            _employeeViewModelService = profileService;
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

        [HttpGet]
        public async Task<IActionResult> EmployeeList(string employeeId)
        {
            var viewModel = new EmployeeViewModel();

            if (!String.IsNullOrEmpty(employeeId))
            {
                viewModel = await _employeeViewModelService.GetEmployeeList(employeeId);
            }
            else
            {
                viewModel = await _employeeViewModelService.GetEmployeeList();
            }

            return View(viewModel);
        }
    }
}