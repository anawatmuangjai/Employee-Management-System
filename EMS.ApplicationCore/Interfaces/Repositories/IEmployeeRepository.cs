using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeeListAsync();
    }
}
