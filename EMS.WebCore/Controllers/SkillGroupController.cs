﻿using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.SkillGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SkillGroupController : Controller
    {
        private readonly ISkillGroupService _skillGroupService;

        public SkillGroupController(ISkillGroupService skillGroupService)
        {
            _skillGroupService = skillGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skillGroups = await _skillGroupService.GetAllAsync();

            var viewModel = new SkillGroupViewModel
            {
                SkillGroups = skillGroups
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
        public async Task<IActionResult> Create(SkillGroupEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var skillGroup = new SkillGroupModel
            {
                SkillGroupName = viewModel.SkillGroupName
            };

            await _skillGroupService.AddAsync(skillGroup);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skillGroup = await _skillGroupService.GetByIdAsync(id);

            if (skillGroup == null)
                return NotFound();

            var editModel = new SkillGroupEditViewModel
            {
                SkillGroupId = skillGroup.SkillGroupId,
                SkillGroupName = skillGroup.SkillGroupName
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SkillGroupEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var editModel = new SkillGroupModel
            {
                SkillGroupId = model.SkillGroupId,
                SkillGroupName = model.SkillGroupName
            };

            await _skillGroupService.UpdateAsync(editModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var skillGroup = await _skillGroupService.GetByIdAsync(id);

            if (skillGroup == null)
                return NotFound();

            return View(skillGroup);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _skillGroupService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}