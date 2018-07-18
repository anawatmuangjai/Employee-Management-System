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
    public class JobService : BaseService<JobModel, MasterJob, IAsyncRepository<MasterJob>>, IJobService
    {
        public JobService(IAsyncRepository<MasterJob> repository) 
            : base(repository)
        {
        }

        public async Task<List<JobModel>> GetByNameAsync(string name)
        {
            var entities = await _repository.GetAsync(x => x.JobTitle.Contains(name));
            return _mapper.Map<List<MasterJob>, List<JobModel>>(entities);
        }
    }
}
