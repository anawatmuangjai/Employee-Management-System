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
    public class JobService : BaseService<JobTitleModel, MasterJobTitle, IAsyncRepository<MasterJobTitle>>, IJobService
    {
        public JobService(IAsyncRepository<MasterJobTitle> repository)
            : base(repository)
        {
        }

        public async Task<List<JobTitleModel>> GetByNameAsync(string name)
        {
            var entities = await _repository.GetAsync(x => x.JobTitle.Contains(name));
            return _mapper.Map<List<MasterJobTitle>, List<JobTitleModel>>(entities);
        }
    }
}
