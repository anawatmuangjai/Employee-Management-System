using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeSkillService
    {
        Task<List<EmployeeSkillModel>> GetByEmployeeId(string employeeId);
        Task AddAsync(EmployeeSkillModel model);
        Task UpdateAsync(EmployeeSkillModel model);
        Task DeleteAsync(string employeeId, int skillId);
    }
}
