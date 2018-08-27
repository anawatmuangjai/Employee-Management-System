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
    public class ShiftService : IShiftService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterShift> _repository;

        public ShiftService(IAsyncRepository<MasterShift> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterShift, ShiftModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<ShiftModel> GetByIdAsync(int id)
        {
            var shift = await _repository.GetSingleAsync(x => x.ShiftId == id);
            return _mapper.Map<MasterShift, ShiftModel>(shift);
        }

        public async Task<List<ShiftModel>> GetAllAsync()
        {
            var shifts = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterShift>, List<ShiftModel>>(shifts);
        }

        public async Task<List<ShiftModel>> GetByNameAsync(string name)
        {
            var shifts = await _repository.GetAsync(x => x.ShiftName == name);
            return _mapper.Map<List<MasterShift>, List<ShiftModel>>(shifts);
        }

        public async Task AddAsync(ShiftModel model)
        {
            var shift = new MasterShift
            {
                ShiftName = model.ShiftName,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };

            await _repository.AddAsync(shift);
        }

        public async Task UpdateAsync(ShiftModel model)
        {
            var shift = await _repository.GetByIdAsync(model.ShiftId);

            shift.ShiftName = model.ShiftName;
            shift.StartTime = model.StartTime;
            shift.EndTime = model.EndTime;

            await _repository.UpdateAsync(shift);
        }

        public async Task DeleteAsync(int id)
        {
            var shift = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(shift);
        }
    }
}
