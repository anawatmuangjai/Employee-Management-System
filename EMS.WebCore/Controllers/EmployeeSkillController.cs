using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.EmployeeSkill;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.WebCore.Controllers
{
    public class EmployeeSkillController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeDetailService _employeeDetailService;
        private readonly IEmployeeSkillService _employeeSkillService;

        public EmployeeSkillController(
            IEmployeeService employeeService,
            IEmployeeDetailService employeeDetailService,
            IEmployeeSkillService employeeSkillService)
        {
            _employeeService = employeeService;
            _employeeDetailService = employeeDetailService;
            _employeeSkillService = employeeSkillService;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(string employeeId)
        {
            var viewModel = new EmployeeSkillViewModel();

            if (!string.IsNullOrEmpty(employeeId))
            {
                viewModel.Employee = await _employeeService.GetByEmployeeIdWithDetailAsync(employeeId);
                viewModel.EmployeeSkills = await _employeeSkillService.GetByEmployeeId(employeeId);
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new EmployeeSkillEditViewModel
            {
                SkillGroups = await _employeeDetailService.GetSkillGroups(),
                SkillTypes = await _employeeDetailService.GetSkillTypes()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeSkillEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var skillGroup = new EmployeeSkillModel
            {
                EmployeeId = viewModel.EmployeeId,
                SkillId = viewModel.SkillId,
                SkillLevel = viewModel.SkillLevel
            };

            await _employeeSkillService.AddAsync(skillGroup);
            return RedirectToAction(nameof(Index), new { employeeId = viewModel.EmployeeId });
        }

        public async Task<JsonResult> GetSkill(int skillGroupId, int skillTypeId)
        {
            var items = await _employeeDetailService.GetSkills(skillGroupId, skillTypeId);

            return Json(new SelectList(items, "Value", "Text"));
        }
    }
}