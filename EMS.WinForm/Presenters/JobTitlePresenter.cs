using EMS.ApplicationCore.Interfaces.Repositories;
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
        private readonly IAsyncRepository<MasterJob> _jobRepository;

        public JobTitlePresenter(
            IJobTitleView view, 
            IAsyncRepository<MasterJob> jobRepository)
        {
            _view = view;
            _view.Presenter = this;
            _jobRepository = jobRepository;
        }

        public IJobTitleView GetView()
        {
            return _view;
        }

        public async Task ViewAll()
        {
            _view.Jobs = await _jobRepository.GetAllAsync();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            var job = new MasterJob
            {
                JobId = _view.JobId,
                JobTitle = _view.JobTitle,
                JobDescription = _view.JobDescription
            };

            if (job.JobId > 0)
                await _jobRepository.UpdateAsync(job);
            else
                await _jobRepository.AddAsync(job);
        }

        public async Task Delete()
        {
            await _jobRepository.DeleteAsync(_view.SelectedJob);
        }
    }
}
