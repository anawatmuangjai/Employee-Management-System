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
    public class EmployeeStateService : IEmployeeStateService
    {
        private readonly IAsyncRepository<EmployeeState> _repository;

        public EmployeeStateService(IAsyncRepository<EmployeeState> repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeStateModel> AddAsync(EmployeeStateModel model)
        {
            var entity = new EmployeeState
            {
                EmployeeId = model.EmployeeId,
                SectionId = model.SectionId,
                ShiftId = model.ShiftId,
                JobTitleId = model.JobTitleId,
                LevelId = model.LevelId,
                BusStationId = model.BusStationId,
                JoinDate = model.JoinDate,
                ChangedDate = model.ChangedDate
            };

            entity = await _repository.AddAsync(entity);
            return MappingEntityAndModel(entity);
        }

        public async Task UpdateAsync(EmployeeStateModel model)
        {
            var entity = await _repository.GetSingleAsync(x => x.EmployeeId == model.EmployeeId);

            entity.SectionId = model.SectionId;
            entity.ShiftId = model.ShiftId;
            entity.JobTitleId = model.JobTitleId;
            entity.LevelId = model.LevelId;
            entity.JoinDate = model.JoinDate;
            entity.ChangedDate = model.ChangedDate;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        private EmployeeStateModel MappingEntityAndModel(EmployeeState employee)
        {
            return new EmployeeStateModel
            {
                EmployeeId = employee.EmployeeId,
                SectionId = employee.SectionId,
                ShiftId = employee.ShiftId,
                JobTitleId = employee.JobTitleId,
                LevelId = employee.LevelId,
                JoinDate = employee.JoinDate,
                ChangedDate = employee.ChangedDate
            };
        }
    }
}
