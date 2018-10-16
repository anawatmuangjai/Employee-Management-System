using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.ViewModels.SkillMapping;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class SkillMappingController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeSkillService _employeeSkillService;

        public SkillMappingController(
            IEmployeeService employeeService, 
            IEmployeeSkillService employeeSkillService)
        {
            _employeeService = employeeService;
            _employeeSkillService = employeeSkillService;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(string firstEmployeeId,string secondEmployeeId)
        {
            var viewModel = new SkillMappingViewModel();

            if (!string.IsNullOrEmpty(firstEmployeeId))
            {
                viewModel.FirstEmployee = await _employeeService.GetByEmployeeIdWithDetailAsync(firstEmployeeId);
                viewModel.FirstEmployeeSkills = await _employeeSkillService.GetByEmployeeId(firstEmployeeId);
            }

            if (!string.IsNullOrEmpty(secondEmployeeId))
            {
                viewModel.SecondEmployee = await _employeeService.GetByEmployeeIdWithDetailAsync(firstEmployeeId);
                viewModel.SecondEmployeeSkills = await _employeeSkillService.GetByEmployeeId(firstEmployeeId);
            }

            return View(viewModel);
        }
    }
}