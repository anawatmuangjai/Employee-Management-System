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
    public class EmployeeAddressService : IEmployeeAddressService
    {
        private readonly IAsyncRepository<EmployeeAddress> _employeeRepository;

        public EmployeeAddressService(IAsyncRepository<EmployeeAddress> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeAddressModel> AddAsync(EmployeeAddressModel model)
        {
            var entity = new EmployeeAddress
            {
                EmployeeAddressId = model.EmployeeAddressId,
                EmployeeId = model.EmployeeId,
                HomeAddress = model.HomeAddress,
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

        public async Task UpdateAsync(EmployeeAddressModel model)
        {
            var entity = await _employeeRepository.GetByIdAsync(model.EmployeeAddressId);

            entity.EmployeeId = model.EmployeeId;
            entity.HomeAddress = model.HomeAddress;
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

        private EmployeeAddressModel MappingEntityAndModel(EmployeeAddress address)
        {
            return new EmployeeAddressModel
            {
                EmployeeAddressId = address.EmployeeAddressId,
                EmployeeId = address.EmployeeId,
                HomeAddress = address.HomeAddress,
                City = address.City,
                Country = address.Country,
                PostalCode = address.PostalCode,
                PhoneNumber = address.PhoneNumber,
                EmailAddress = address.EmailAddress,
                ChangedDate = address.ChangedDate,
            };
        }
    }
}
