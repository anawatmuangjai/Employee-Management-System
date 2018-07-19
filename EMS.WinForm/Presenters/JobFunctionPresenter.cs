using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class JobFunctionPresenter : IJobFunctionPresenter
    {
        private readonly IJobFunctionView _view;
        private readonly IJobService _jobService;
        private readonly IJobFunctionService _jobFunctionService;

        public JobFunctionPresenter(
            IJobFunctionView view, 
            IJobService jobService, 
            IJobFunctionService jobFunctionService)
        {
            _view = view;
            _view.Presenter = this;
            _jobService = jobService;
            _jobFunctionService = jobFunctionService;
        }

        public IJobFunctionView GetView()
        {
            return _view;
        }

        public async Task GetJobTitleAsync()
        {
            _view.JobModels = await _jobService.GetAllAsync();
        }

        public async Task ViewAllAsync()
        {
            _view.JobJobFunctions = await _jobFunctionService.GetAllAsync();
        }

        public async Task SearchAsync()
        {
            _view.JobJobFunctions = await _jobFunctionService.GetByNameAsync(_view.Filter);
        }

        public async Task SaveAsync()
        {
            var job = new JobFunctionModel
            {
                JobFunctionId = _view.JobFunctionId,
                JobId = _view.JobId,
                FunctionName = _view.FunctionName,
                FunctionDescription = _view.FunctionDescription
            };

            if (job.JobFunctionId > 0)
                await _jobFunctionService.UpdateAsync(job);
            else
                await _jobFunctionService.AddAsync(job);
        }

        public async Task DeleteAsync()
        {
            await _jobFunctionService.DeleteAsync(_view.SelectedJobFunction);
        }
    }
}
