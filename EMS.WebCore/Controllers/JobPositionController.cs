using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.JobPosition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    [Authorize]
    public class JobPositionController : Controller
    {
        private readonly IJobPositionService _jobPositionService;

        public JobPositionController(IJobPositionService jobPositionService)
        {
            _jobPositionService = jobPositionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobPositions = await _jobPositionService.GetAllAsync();

            var viewModel = new JobViewModel
            {
                JobTitles = jobPositions
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var jobPosition = new JobPositionModel
            {
                PositionName = model.PositionName,
                PositionCode = model.PositionCode
            };

            await _jobPositionService.AddAsync(jobPosition);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jobPosition = await _jobPositionService.GetByIdAsync(id);

            if (jobPosition == null)
                return NotFound();

            var editViewModel = new JobEditViewModel
            {
                PositionId = jobPosition.PositionId,
                PositionName = jobPosition.PositionName,
                PositionCode = jobPosition.PositionCode
            };

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var jobPosition = new JobPositionModel
            {
                PositionId = model.PositionId,
                PositionName = model.PositionName,
                PositionCode = model.PositionCode
            };

            await _jobPositionService.UpdateAsync(jobPosition);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var jobPosition = await _jobPositionService.GetByIdAsync(id);

            if (jobPosition == null)
                return NotFound();

            return View(jobPosition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobPositionService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}