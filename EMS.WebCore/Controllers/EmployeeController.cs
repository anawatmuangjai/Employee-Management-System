using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.Domain.Entities;
using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeListService _employeeListService;

        public EmployeeController(IEmployeeListService employeeListService)
        {
            _employeeListService = employeeListService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
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