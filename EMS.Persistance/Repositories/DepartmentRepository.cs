using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain.Entities;
using EMS.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Persistance.Repositories
{
    public class DepartmentRepository : Repository<MasterDepartment>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeContext dbContext) 
            : base(dbContext)
        {
        }

        public IEnumerable<MasterDepartment> GetByName(string name)
        {
            return _dbContext.MasterDepartment
                .Where(x => x.DepartmentName.Contains(name))
                .AsEnumerable();
        }
    }
}
