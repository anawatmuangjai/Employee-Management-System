using EMS.ApplicationCore.Interfaces.Repositories;
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
    public class JobTitlePresenter : IJobTitlePresenter
    {
        private readonly IJobTitleView _view;
        private readonly IJobService _jobService;

        public JobTitlePresenter(IJobTitleView view, IJobService jobService)
        {
            _view = view;
            _view.Presenter = this;
            _jobService = jobService;
        }

        public IJobTitleView GetView()
        {
            return _view;
        }

        public async Task ViewAllAsync()
        {
            _view.Jobs = await _jobService.GetAllAsync();
        }

        public async Task SearchAsync()
        {
            _view.Jobs = await _jobService.GetByNameAsync(_view.Filter);
        }

        public async Task SaveAsync()
        {
            var job = new JobModel
            {
                JobId = _view.JobId,
                JobTitle = _view.JobTitle,
                JobDescription = _view.JobDescription
            };

            if (job.JobId > 0)
                await _jobService.UpdateAsync(job);
            else
                await _jobService.AddAsync(job);
        }

        public async Task DeleteAsync()
        {
            await _jobService.DeleteAsync(_view.SelectedJob);
        }
    }
}
