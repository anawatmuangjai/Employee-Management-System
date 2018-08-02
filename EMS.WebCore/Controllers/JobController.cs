using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.ViewModels.Job;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IJobFunctionService _jobFunctionService;

        public JobController(IJobService jobService, IJobFunctionService jobFunctionService)
        {
            _jobService = jobService;
            _jobFunctionService = jobFunctionService;
        }

        public async Task<IActionResult> Index()
        {
            var jobTitles = await _jobService.GetAllAsync();

            var viewModel = new JobViewModel
            {
                JobTitles = jobTitles
            };

            return View(viewModel);
        }
    }
}