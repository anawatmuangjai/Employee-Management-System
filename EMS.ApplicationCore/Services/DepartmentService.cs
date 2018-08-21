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
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterDepartment> _departmentRepository;

        public DepartmentService(IAsyncRepository<MasterDepartment> departmentRepository)
        {
            _departmentRepository = departmentRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterDepartment, DepartmentModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<DepartmentModel> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return _mapper.Map<MasterDepartment, DepartmentModel>(department);
        }

        public async Task<List<DepartmentModel>> GetAllAsync()
        {
            var department = await _departmentRepository.GetAllAsync();
            return _mapper.Map<List<MasterDepartment>, List<DepartmentModel>>(department);
        }

        public async Task<List<DepartmentModel>> GetByNameAsync(string name)
        {
            var department = await _departmentRepository.GetAsync(x => x.DepartmentName == name);
            return _mapper.Map<List<MasterDepartment>, List<DepartmentModel>>(department);
        }

        public async Task AddAsync(DepartmentModel model)
        {
            var department = new MasterDepartment
            {
                DepartmentId = model.DepartmentId,
                DepartmentName = model.DepartmentName,
                DepartmentCode = model.DepartmentCode,
                DepartmentGroup = model.DepartmentGroup
            };

            await _departmentRepository.AddAsync(department);
        }

        public async Task UpdateAsync(DepartmentModel model)
        {
            var department = await _departmentRepository.GetByIdAsync(model.DepartmentId);

            department.DepartmentName = model.DepartmentName;
            department.DepartmentCode = model.DepartmentCode;
            department.DepartmentGroup = model.DepartmentName;

            await _departmentRepository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            await _departmentRepository.DeleteAsync(department);
        }
    }
}
