using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Interfaces.Repositories
{
    public interface ISectionRepository : IRepository<MasterSection>, IAsyncRepository<MasterSection>
    {
        IEnumerable<MasterSection> GetAllWithDepartment();
        IEnumerable<MasterSection> GetByNameWithDepartment(string name);
    }
}
