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
        private readonly IAsyncRepository<MasterDepartment> _departmentRepository;

        public DepartmentService(IAsyncRepository<MasterDepartment> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartmentModel>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
