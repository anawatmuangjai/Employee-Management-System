using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Skill;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IEmployeeDetailService _employeeDetailService;

        public SkillController(
            ISkillService skillService,
            IEmployeeDetailService employeeDetailService)
        {
            _skillService = skillService;
            _employeeDetailService = employeeDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skills = await _skillService.GetAllAsync();

            var viewModel = new SkillViewModel
            {
                Skills = skills
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new SkillEditViewModel
            {
                SkillGroups = await _employeeDetailService.GetSkillGroups(),
                SkillTypes = await _employeeDetailService.GetSkillTypes()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var skillGroup = new SkillModel
            {
                SkillGroupId = viewModel.SkillGroupId,
                SkillTypeId = viewModel.SkillTypeId,
                SkillName = viewModel.SkillName,
                SkillDescription = viewModel.SkillDescription,
            };

            await _skillService.AddAsync(skillGroup);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _skillService.GetByIdAsync(id);

            if (skill == null)
                return NotFound();

            var editModel = new SkillEditViewModel
            {
                SkillId = skill.SkillId,
                SkillGroupId = skill.SkillGroupId,
                SkillTypeId = skill.SkillTypeId,
                SkillName = skill.SkillName,
                SkillDescription = skill.SkillDescription,
                SkillGroups = await _employeeDetailService.GetSkillGroups(),
                SkillTypes = await _employeeDetailService.GetSkillTypes()
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SkillEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var editModel = new SkillModel
            {
                SkillId = model.SkillId,
                SkillGroupId = model.SkillGroupId,
                SkillTypeId = model.SkillTypeId,
                SkillName = model.SkillName,
                SkillDescription = model.SkillDescription
            };

            await _skillService.UpdateAsync(editModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var skillGroup = await _skillService.GetByIdAsync(id);

            if (skillGroup == null)
                return NotFound();

            return View(skillGroup);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _skillService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}