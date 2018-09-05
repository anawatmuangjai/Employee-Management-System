using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Major;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class MajorController : Controller
    {
        private readonly IEducationMajorService _majorService;

        public MajorController(IEducationMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var majors = await _majorService.GetAllAsync();

            var viewModel = new MajorViewModel
            {
                Majors = majors
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
        public async Task<IActionResult> Create(MajorEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var degree = new EducationMajorModel
            {
                DegreeId = model.DegreeId,
                MarjorName = model.MarjorName,
                MajorNameThai = model.MajorNameThai
            };

            await _majorService.AddAsync(degree);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var major = await _majorService.GetByIdAsync(id);

            if (major == null)
                return NotFound();

            var editModel = new MajorEditViewModel
            {
                MajorId = major.MajorId,
                DegreeId = major.DegreeId,
                MarjorName = major.MarjorName,
                MajorNameThai = major.MajorNameThai
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MajorEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var degree = new EducationMajorModel
            {
                MajorId = model.MajorId,
                DegreeId = model.DegreeId,
                MarjorName = model.MarjorName,
                MajorNameThai = model.MajorNameThai
            };

            await _majorService.UpdateAsync(degree);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var degree = await _majorService.GetByIdAsync(id);

            if (degree == null)
                return NotFound();

            return View(degree);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _majorService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}