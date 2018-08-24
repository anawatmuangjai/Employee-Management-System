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
    public class EmployeeLevelService : IEmployeeLevelService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterLevel> _repository;

        public EmployeeLevelService(IAsyncRepository<MasterLevel> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterLevel, EmployeeLevelModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<EmployeeLevelModel> GetByIdAsync(int id)
        {
            var level = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterLevel, EmployeeLevelModel>(level);
        }

        public async Task<List<EmployeeLevelModel>> GetAllAsync()
        {
            var levels = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterLevel>, List<EmployeeLevelModel>>(levels);
        }

        public async Task<List<EmployeeLevelModel>> GetByNameAsync(string name)
        {
            var levels = await _repository.GetAsync(x => x.LevelName == name);
            return _mapper.Map<List<MasterLevel>, List<EmployeeLevelModel>>(levels);
        }

        public async Task AddAsync(EmployeeLevelModel model)
        {
            var level = new MasterLevel
            {
                LevelName = model.LevelName,
                LevelCode = model.LevelCode
            };

            await _repository.AddAsync(level);
        }

        public async Task UpdateAsync(EmployeeLevelModel model)
        {
            var level = await _repository.GetByIdAsync(model.LevelId);

            level.LevelName = model.LevelName;
            level.LevelCode = model.LevelCode;

            await _repository.UpdateAsync(level);
        }

        public async Task DeleteAsync(int id)
        {
            var level = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(level);
        }

    }
}
