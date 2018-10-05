using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface ISkillGroupService
    {
        Task<SkillGroupModel> GetByIdAsync(int id);
        Task<List<SkillGroupModel>> GetAllAsync();
        Task AddAsync(SkillGroupModel model);
        Task UpdateAsync(SkillGroupModel model);
        Task DeleteAsync(int id);
    }
}
