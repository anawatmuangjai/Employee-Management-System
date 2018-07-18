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
    public class DepartmentService : BaseService<DepartmentModel, MasterDepartment, IAsyncRepository<MasterDepartment>>, IDepartmentService
    {
        public DepartmentService(IAsyncRepository<MasterDepartment> repository) 
            : base(repository)
        {
        }

        public async Task<List<DepartmentModel>> GetByNameAsync(string name)
        {
            var entities = await _repository.GetAsync(x => x.DepartmentName.Contains(name));
            return _mapper.Map<List<MasterDepartment>, List<DepartmentModel>>(entities);
        }
    }
}
