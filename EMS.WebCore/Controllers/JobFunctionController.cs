using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.JobFunction;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class JobFunctionController : Controller
    {
        private readonly IJobFunctionService _jobFunctionService;

        public JobFunctionController(IJobFunctionService jobFunctionService)
        {
            _jobFunctionService = jobFunctionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobFunctions = await _jobFunctionService.GetAllAsync();

            if (jobFunctions == null)
                return View();

            var viewModel = new JobFunctionViewModel
            {
                JobFunctions = jobFunctions
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
        public async Task<IActionResult> Create(JobFunctionEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var jobFunction = new JobFunctionModel
            {
                JobTitleId = model.JobTitleId,
                FunctionName = model.FunctionName,
                FunctionDescription = model.FunctionDescription
            };

            await _jobFunctionService.AddAsync(jobFunction);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jobFunction = await _jobFunctionService.GetByIdAsync(id);

            if (jobFunction == null)
                return NotFound();

            return View(jobFunction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobFunctionEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var jobFunction = new JobFunctionModel
            {
                JobFunctionId = model.JobFunctionId,
                JobTitleId = model.JobTitleId,
                FunctionName = model.FunctionName,
                FunctionDescription = model.FunctionName
            };

            await _jobFunctionService.UpdateAsync(jobFunction);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var jobFunction = await _jobFunctionService.GetByIdAsync(id);

            if (jobFunction == null)
                return NotFound();

            return View(jobFunction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobFunctionService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}