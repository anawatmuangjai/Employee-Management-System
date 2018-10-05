using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface ISkillTypeService
    {
        Task<SkillTypeModel> GetByIdAsync(int id);
        Task<List<SkillTypeModel>> GetAllAsync();
        Task AddAsync(SkillTypeModel model);
        Task UpdateAsync(SkillTypeModel model);
        Task DeleteAsync(int id);
    }
}
