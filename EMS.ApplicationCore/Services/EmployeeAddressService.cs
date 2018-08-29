using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeeAddress> _repository;

        public EmployeeAddressService(IAsyncRepository<EmployeeAddress> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeAddress, EmployeeAddressModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<EmployeeAddressModel> GetByEmployeeId(string employeeId)
        {
            var entity = await _repository.GetSingleAsync(x => x.EmployeeId == employeeId);
            return _mapper.Map<EmployeeAddress, EmployeeAddressModel>(entity);
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

            entity = await _repository.AddAsync(entity);
            return _mapper.Map<EmployeeAddress, EmployeeAddressModel>(entity);
        }

        public async Task UpdateAsync(EmployeeAddressModel model)
        {
            var entity = await _repository.GetByIdAsync(model.EmployeeAddressId);

            if (entity != null)
            {
                entity.EmployeeId = model.EmployeeId;
                entity.HomeAddress = model.HomeAddress;
                entity.City = model.City;
                entity.Country = model.Country;
                entity.PostalCode = model.PostalCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.EmailAddress = model.EmailAddress;
                entity.ChangedDate = model.ChangedDate;

                await _repository.UpdateAsync(entity);
            }
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
    }
}
