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
    public class JobPositiobService : IJobPositionService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterJobPosition> _repository;

        public JobPositiobService(IAsyncRepository<MasterJobPosition> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterJobPosition, JobPositionModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<JobPositionModel> GetByIdAsync(int id)
        {
            var position = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterJobPosition, JobPositionModel>(position);
        }

        public async Task<List<JobPositionModel>> GetAllAsync()
        {
            var position = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterJobPosition>, List<JobPositionModel>>(position);
        }

        public async Task<List<JobPositionModel>> GetByNameAsync(string name)
        {
            var position = await _repository.GetAsync(x => x.PositionName == name);
            return _mapper.Map<List<MasterJobPosition>, List<JobPositionModel>>(position);
        }

        public async Task AddAsync(JobPositionModel model)
        {
            var position = new MasterJobPosition
            {
                PositionName = model.PositionName,
                PositionCode = model.PositionCode
            };

            await _repository.AddAsync(position);
        }

        public async Task UpdateAsync(JobPositionModel model)
        {
            var position = await _repository.GetByIdAsync(model.PositionId);

            position.PositionName = model.PositionName;
            position.PositionCode = model.PositionCode;

            await _repository.UpdateAsync(position);
        }

        public async Task DeleteAsync(int id)
        {
            var position = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(position);
        }
    }
}
