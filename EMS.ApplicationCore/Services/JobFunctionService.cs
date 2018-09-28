using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.ApplicationCore.Specifications;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class JobFunctionService : IJobFunctionService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterJobFunction> _repository;

        public JobFunctionService(IAsyncRepository<MasterJobFunction> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterJobFunction, JobFunctionModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<JobFunctionModel> GetByIdAsync(int id)
        {
            var jobFunction = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterJobFunction, JobFunctionModel>(jobFunction);
        }

        public async Task<List<JobFunctionModel>> GetAllAsync()
        {
            var spec = new JobFunctionSpecification(x => x.FunctionName != null);
            var jobFunctions = await _repository.GetAsync(spec);

            return _mapper.Map<List<MasterJobFunction>, List<JobFunctionModel>>(jobFunctions);
        }

        public async Task<List<JobFunctionModel>> GetByNameAsync(string name)
        {
            var jobFunctions = await _repository.GetAsync(x => x.FunctionName == name);
            return _mapper.Map<List<MasterJobFunction>, List<JobFunctionModel>>(jobFunctions);
        }

        public async Task<List<JobFunctionModel>> GetBySectionIdAsync(int sectionId)
        {
            var jobFunctions = await _repository.GetAsync(x => x.SectionId == sectionId);
            return _mapper.Map<List<MasterJobFunction>, List<JobFunctionModel>>(jobFunctions);
        }

        public async Task AddAsync(JobFunctionModel model)
        {
            var jobFunction = new MasterJobFunction
            {
                SectionId = model.SectionId,
                FunctionName = model.FunctionName,
                FunctionCode = model.FunctionCode,
            };

            await _repository.AddAsync(jobFunction);
        }

        public async Task UpdateAsync(JobFunctionModel model)
        {
            var jobFunction = await _repository.GetByIdAsync(model.JobFunctionId);

            jobFunction.SectionId = model.SectionId;
            jobFunction.FunctionName = model.FunctionName;
            jobFunction.FunctionCode = model.FunctionCode;

            await _repository.UpdateAsync(jobFunction);
        }

        public async Task DeleteAsync(int id)
        {
            var jobFunction = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(jobFunction);
        }


    }
}
