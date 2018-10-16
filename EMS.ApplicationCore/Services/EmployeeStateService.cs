﻿using AutoMapper;
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
    public class EmployeeStateService : IEmployeeStateService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeState> _repository;

        public EmployeeStateService(IAsyncRepository<EmployeeState> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeState, EmployeeStateModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<List<EmployeeStateModel>> GetAllAsync()
        {
            var spec = new EmployeeStateSpecification(x => x.Employee.AvailableFlag == true);
            var entity = await _repository.GetAsync(spec);
            return _mapper.Map<List<EmployeeState>, List<EmployeeStateModel>>(entity);
        }

        public async Task<EmployeeStateModel> GetByEmployeeId(string employeeId)
        {
            var entity = await _repository.GetSingleAsync(x => x.EmployeeId == employeeId);
            return _mapper.Map<EmployeeState, EmployeeStateModel>(entity);
        }

        public async Task<EmployeeStateModel> AddAsync(EmployeeStateModel model)
        {
            var entity = new EmployeeState
            {
                PositionId = model.PositionId,
                JobFunctionId = model.JobFunctionId,
                EmployeeId = model.EmployeeId,
                ShiftId = model.ShiftId,
                LevelId = model.LevelId,
                BusStationId = model.BusStationId,
                JoinDate = model.JoinDate,
                ChangedDate = model.ChangedDate
            };

            entity = await _repository.AddAsync(entity);
            return _mapper.Map<EmployeeState, EmployeeStateModel>(entity);
        }

        public async Task UpdateAsync(EmployeeStateModel model)
        {
            var entity = await _repository.GetSingleAsync(x => x.EmployeeId == model.EmployeeId);

            entity.PositionId = model.PositionId;
            entity.JobFunctionId = model.JobFunctionId;
            entity.ShiftId = model.ShiftId;
            entity.LevelId = model.LevelId;
            entity.BusStationId = model.BusStationId;
            entity.JoinDate = model.JoinDate;
            entity.ChangedDate = model.ChangedDate;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<bool> ExistsAsync(string employeeId)
        {
            return await _repository.ExistsAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<int> CountShiftAsync(int shiftId)
        {
            return await _repository.CountAsync(x => x.ShiftId == shiftId);
        }


    }
}
