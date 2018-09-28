using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Level;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LevelController : Controller
    {
        private readonly IEmployeeLevelService _levelService;

        public LevelController(IEmployeeLevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var levels = await _levelService.GetAllAsync();

            var viewModel = new LevelViewModel
            {
                EmployeeLevels = levels
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
        public async Task<IActionResult> Create(LevelEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var level = new EmployeeLevelModel
            {
                LevelName = model.LevelName,
                LevelCode = model.LevelCode
            };

            await _levelService.AddAsync(level);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var level = await _levelService.GetByIdAsync(id);

            if (level == null)
                return NotFound();

            var editModel = new LevelEditViewModel
            {
                LevelId = level.LevelId,
                LevelName = level.LevelName,
                LevelCode = level.LevelCode
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LevelEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var level = new EmployeeLevelModel
            {
                LevelId = model.LevelId,
                LevelName = model.LevelName,
                LevelCode = model.LevelCode
            };

            await _levelService.UpdateAsync(level);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var level = await _levelService.GetByIdAsync(id);

            if (level == null)
                return NotFound();

            return View(level);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _levelService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}