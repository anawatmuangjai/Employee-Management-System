using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface ISkillService
    {
        Task<SkillModel> GetByIdAsync(int id);
        Task<List<SkillModel>> GetAllAsync();
        Task AddAsync(SkillModel model);
        Task UpdateAsync(SkillModel model);
        Task DeleteAsync(int id);
    }
}
