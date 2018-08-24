using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Job;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobTitles = await _jobService.GetAllAsync();

            var viewModel = new JobViewModel
            {
                JobTitles = jobTitles
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

            var jobTitle = new JobTitleModel
            {
                JobTitle = model.JobTitle,
                JobDescription = model.JobDescription
            };

            await _jobService.AddAsync(jobTitle);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jobTitle = await _jobService.GetByIdAsync(id);

            if (jobTitle == null)
                return NotFound();

            var editViewModel = new JobEditViewModel
            {
                JobTitleId = jobTitle.JobTitleId,
                JobTitle = jobTitle.JobTitle,
                JobDescription = jobTitle.JobDescription
            };

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var jobTitle = new JobTitleModel
            {
                JobTitleId = model.JobTitleId,
                JobTitle = model.JobTitle,
                JobDescription = model.JobDescription
            };

            await _jobService.UpdateAsync(jobTitle);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var jobTitle = await _jobService.GetByIdAsync(id);

            if (jobTitle == null)
                return NotFound();

            return View(jobTitle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}