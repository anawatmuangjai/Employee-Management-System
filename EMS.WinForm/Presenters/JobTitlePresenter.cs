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

        public void ViewAll()
        {
            _view.Jobs = _jobService.GetAll().ToList();
        }

        public void Search()
        {
            _view.Jobs = _jobService.GetByName(_view.Filter).ToList();
        }

        public void Save()
        {
            var job = new JobModel
            {
                JobId = _view.JobId,
                JobTitle = _view.JobTitle,
                JobDescription = _view.JobDescription
            };

            if (job.JobId > 0)
                _jobService.Update(job);
            else
                _jobService.Add(job);
        }

        public void Delete()
        {
            _jobService.Delete(_view.SelectedJob);
        }
    }
}
