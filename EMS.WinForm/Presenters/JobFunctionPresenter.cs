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
    public class JobFunctionPresenter : IJobFunctionPresenter
    {
        private readonly IJobFunctionView _view;
        private readonly IAsyncRepository<MasterJobFunction> _jobFunctionRepository;

        public JobFunctionPresenter(
            IJobFunctionView view, 
            IAsyncRepository<MasterJobFunction> jobFunctionRepository)
        {
            _view = view;
            _view.Presenter = this;
            _jobFunctionRepository = jobFunctionRepository;
        }

        public IJobFunctionView GetView()
        {
            return _view;
        }

        public async Task ViewAll()
        {
            _view.JobJobFunctions = await _jobFunctionRepository.GetAllAsync();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            var job = new MasterJobFunction
            {
                JobFunctionId = _view.JobFunctionId,
                JobId = _view.JobId,
                FunctionName = _view.FunctionName,
                FunctionDescription = _view.FunctionDescription
            };

            if (job.JobId > 0)
                await _jobFunctionRepository.UpdateAsync(job);
            else
                await _jobFunctionRepository.AddAsync(job);
        }

        public async Task Delete()
        {
            await _jobFunctionRepository.DeleteAsync(_view.SelectedJobFunction);
        }
    }
}
