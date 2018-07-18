using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Services
{
    public class EmployeeLevelService : BaseService<EmployeeLevelModel, MasterLevel, IAsyncRepository<MasterLevel>>, IEmployeeLevelService
    {
        public EmployeeLevelService(IAsyncRepository<MasterLevel> repository) 
            : base(repository)
        {
        }
    }
}
