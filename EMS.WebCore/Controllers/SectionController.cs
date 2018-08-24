using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Section;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    [Authorize]
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sections = await _sectionService.GetAllAsync();

            var viewModel = new SectionViewModel
            {
                Sections = sections
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
        public async Task<IActionResult> Create(SectionEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var section = new SectionModel
                {
                    DepartmentId = model.DepartmentId,
                    SectionName = model.SectionName,
                    SectionCode = model.SectionCode
                };

                await _sectionService.AddAsync(section);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var section = await _sectionService.GetByIdAsync(id);

            if (section == null)
                return NotFound();

            var editViewModel = new SectionEditViewModel
            {
                SectionId = section.SectionId,
                DepartmentId = section.DepartmentId,
                SectionName = section.SectionName,
                SectionCode = section.SectionCode
            };

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SectionEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var section = new SectionModel
            {
                SectionId = model.SectionId,
                DepartmentId = model.DepartmentId,
                SectionName = model.SectionName,
                SectionCode = model.SectionCode
            };

            await _sectionService.UpdateAsync(section);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var section = await _sectionService.GetByIdAsync(id);

            if (section == null)
                return NotFound();

            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sectionService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}