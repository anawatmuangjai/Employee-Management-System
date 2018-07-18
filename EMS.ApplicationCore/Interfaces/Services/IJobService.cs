using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IJobService : IService<JobModel, MasterJob, IRepository<MasterJob>>
    {
        IEnumerable<JobModel> GetByName(string name);
    }
}
