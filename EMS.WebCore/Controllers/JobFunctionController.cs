using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.JobFunction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.WebCore.Controllers
{
    public class JobFunctionController : Controller
    {
        private readonly IJobFunctionService _jobFunctionService;
        private readonly IJobPositionService _jobPositionService;

        public JobFunctionController(
            IJobFunctionService jobFunctionService,
            IJobPositionService jobPositionService)
        {
            _jobFunctionService = jobFunctionService;
            _jobPositionService = jobPositionService;
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

            var editViewModel = new JobFunctionEditViewModel
            {
                JobFunctionId = jobFunction.JobFunctionId,
                FunctionName = jobFunction.FunctionName,
                FunctionDescription = jobFunction.FunctionDescription,
            };

            return View(editViewModel);
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

        private async Task<IEnumerable<SelectListItem>> GetJobTitle()
        {
            var jobTitles = await _jobPositionService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var job in jobTitles)
            {
                item.Add(new SelectListItem()
                {
                    Value = job.PositionId.ToString(),
                    Text = job.PositionName
                });
            }

            return item;
        }
    }
}