using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Services
{
    public class JobService : BaseService<JobModel, MasterJob, IRepository<MasterJob>>, IJobService
    {
        public JobService(IRepository<MasterJob> repository)
            : base(repository)
        {
        }

        public IEnumerable<JobModel> GetByName(string name)
        {
            var entities = _repository.Get(x => x.JobTitle.Contains(name));

            var model = _mapper.Map<IEnumerable<MasterJob>, IEnumerable<JobModel>>(entities);

            return model;
        }
    }
}
