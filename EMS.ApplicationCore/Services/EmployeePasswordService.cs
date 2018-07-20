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
    public class EmployeePasswordService : IEmployeePasswordService
    {
        private readonly IAsyncRepository<EmployeePassword> _repository;

        public EmployeePasswordService(IAsyncRepository<EmployeePassword> repository)
        {
            _repository = repository;
        }

        public Task<EmployeePasswordModel> GetByEmployeeId(string employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeePasswordModel> AddAsync(EmployeePasswordModel model)
        {
            var entity = new EmployeePassword
            {
                EmployeeId = model.EmployeeId,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                ChangedDate = model.ChangedDate
            };

            entity = await _repository.AddAsync(entity);
            return MappingEntityAndModel(entity);
        }


        public async Task UpdateAsync(EmployeePasswordModel model)
        {
            var entity = await _repository.GetSingleAsync(x => x.EmployeeId == model.EmployeeId);

            entity.PasswordHash = model.PasswordHash;
            entity.PasswordSalt = model.PasswordSalt;
            entity.ChangedDate = model.ChangedDate;

            await _repository.UpdateAsync(entity);
        }

        private EmployeePasswordModel MappingEntityAndModel(EmployeePassword entity)
        {
            return new EmployeePasswordModel
            {
                EmployeeId = entity.EmployeeId,
                PasswordHash = entity.PasswordHash,
                PasswordSalt = entity.PasswordSalt,
                ChangedDate = entity.ChangedDate
            };
        }
    }
}
