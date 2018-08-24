using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class JobService : IJobService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterJobTitle> _repository;

        public JobService(IAsyncRepository<MasterJobTitle> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterJobTitle, JobTitleModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<JobTitleModel> GetByIdAsync(int id)
        {
            var jobTitle = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterJobTitle, JobTitleModel>(jobTitle);
        }

        public async Task<List<JobTitleModel>> GetAllAsync()
        {
            var jobTitles = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterJobTitle>, List<JobTitleModel>>(jobTitles);
        }

        public async Task<List<JobTitleModel>> GetByNameAsync(string name)
        {
            var jobTitles = await _repository.GetAsync(x => x.JobTitle == name);
            return _mapper.Map<List<MasterJobTitle>, List<JobTitleModel>>(jobTitles);
        }

        public async Task AddAsync(JobTitleModel model)
        {
            var jobTitle = new MasterJobTitle
            {
                JobTitle = model.JobTitle,
                JobDescription = model.JobDescription
            };

            await _repository.AddAsync(jobTitle);
        }

        public async Task UpdateAsync(JobTitleModel model)
        {
            var jobTitle = await _repository.GetByIdAsync(model.JobTitleId);

            jobTitle.JobTitle = model.JobTitle;
            jobTitle.JobDescription = model.JobDescription;

            await _repository.UpdateAsync(jobTitle);
        }

        public async Task DeleteAsync(int id)
        {
            var jobTitle = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(jobTitle);
        }
    }
}
