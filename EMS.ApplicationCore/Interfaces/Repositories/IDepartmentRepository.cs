using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IDepartmentRepository : IRepository<MasterDepartment>,IAsyncRepository<MasterDepartment>
    {
        IEnumerable<MasterDepartment> GetByName(string name);
    }
}
