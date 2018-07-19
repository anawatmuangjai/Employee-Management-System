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
    public class JobFunctionService : BaseService<JobFunctionModel, MasterJobFunction, IAsyncRepository<MasterJobFunction>>, IJobFunctionService
    {
        public JobFunctionService(IAsyncRepository<MasterJobFunction> repository) 
            : base(repository)
        {
        }

        public async Task<List<JobFunctionModel>> GetByNameAsync(string name)
        {
            var entities = await _repository.GetAsync(x => x.FunctionName.Contains(name));
            return _mapper.Map<List<MasterJobFunction>, List<JobFunctionModel>>(entities);
        }
    }
}
