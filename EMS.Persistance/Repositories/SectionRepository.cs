using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Persistance.Repositories
{
    public class SectionRepository : Repository<MasterSection>, ISectionRepository
    {
        public SectionRepository(Context.EmployeeContext dbContext) 
            : base(dbContext)
        {
        }

        public IEnumerable<MasterSection> GetAllWithDepartment()
        {
            return _dbContext.MasterSection
                .Include(x => x.Department)
                .AsEnumerable();
        }

        public IEnumerable<MasterSection> GetByNameWithDepartment(string name)
        {
            return _dbContext.MasterSection
                .Where(x => x.SectionName == name)
                .Include(x => x.Department)
                .AsEnumerable();
        }
    }
}
