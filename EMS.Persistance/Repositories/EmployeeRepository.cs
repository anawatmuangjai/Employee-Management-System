﻿using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain.Entities;
using EMS.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<Employee>> GetProfileAsync()
        {
            var result = await _dbContext.Employee
                .Include(image => image.EmployeeImage)
                .Include(state => state.EmployeeState)
                    .ThenInclude(pos => pos.Position)
                .Include(state => state.EmployeeState)
                    .ThenInclude(job => job.JobFunction)
                    .ThenInclude(sec => sec.Section)
                    .ThenInclude(dep => dep.Department)
                .ToListAsync();

            return result;
        }
    }
}
