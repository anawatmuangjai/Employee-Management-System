using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class EmployeeDetailService : IEmployeeDetailService
    {
        private readonly IAsyncRepository<EmployeeDetail> _employeeRepository;

        public EmployeeDetailService(IAsyncRepository<EmployeeDetail> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDetailModel> AddAsync(EmployeeDetailModel model)
        {
            var entity = new EmployeeDetail
            {
                EmployeeDetailId = model.EmployeeDetailId,
                EmployeeId = model.EmployeeId,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
                ChangedDate = model.ChangedDate,
            };

            entity = await _employeeRepository.AddAsync(entity);
            return MappingEntityAndModel(entity);
        }

        public async Task UpdateAsync(EmployeeDetailModel model)
        {
            var entity = await _employeeRepository.GetByIdAsync(model.EmployeeDetailId);

            entity.EmployeeId = model.EmployeeId;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Country = model.Country;
            entity.PostalCode = model.PostalCode;
            entity.PhoneNumber = model.PhoneNumber;
            entity.EmailAddress = model.EmailAddress;      
            entity.ChangedDate = model.ChangedDate;

            await _employeeRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(entity);
        }

        private EmployeeDetailModel MappingEntityAndModel(EmployeeDetail detail)
        {
            return new EmployeeDetailModel
            {
                EmployeeDetailId = detail.EmployeeDetailId,
                EmployeeId = detail.EmployeeId,
                Address = detail.Address,
                City = detail.City,
                Country = detail.Country,
                PostalCode = detail.PostalCode,
                PhoneNumber = detail.PhoneNumber,
                EmailAddress = detail.EmailAddress,
                ChangedDate = detail.ChangedDate,
            };
        }
    }
}
