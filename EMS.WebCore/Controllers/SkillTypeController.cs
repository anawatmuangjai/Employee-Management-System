using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.SkillType;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class SkillTypeController : Controller
    {
        private readonly ISkillTypeService _skillTypeService;

        public SkillTypeController(ISkillTypeService skillTypeService)
        {
            _skillTypeService = skillTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skillTypes = await _skillTypeService.GetAllAsync();

            var viewModel = new SkillTypeViewModel
            {
                SkillTypes = skillTypes
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillTypeEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var skillType = new SkillTypeModel
            {
                SkillTypeName = viewModel.SkillTypeName
            };

            await _skillTypeService.AddAsync(skillType);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skillType = await _skillTypeService.GetByIdAsync(id);

            if (skillType == null)
                return NotFound();

            var editModel = new SkillTypeEditViewModel
            {
                SkillTypeId = skillType.SkillTypeId,
                SkillTypeName = skillType.SkillTypeName
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SkillTypeEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var editModel = new SkillTypeModel
            {
                SkillTypeId = model.SkillTypeId,
                SkillTypeName = model.SkillTypeName
            };

            await _skillTypeService.UpdateAsync(editModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var skillGroup = await _skillTypeService.GetByIdAsync(id);

            if (skillGroup == null)
                return NotFound();

            return View(skillGroup);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _skillTypeService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}