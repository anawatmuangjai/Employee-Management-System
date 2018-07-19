using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IJobService : IService<JobModel, MasterJob, IAsyncRepository<MasterJob>>
    {
        Task<List<JobModel>> GetByNameAsync(string name);
    }
}
