using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface ISectionService
    {
        Task<SectionModel> GetByIdAsync(int id);
        Task<List<SectionModel>> GetAllAsync();
        Task<List<SectionModel>> GetByNameAsync(string name);
        Task AddAsync(SectionModel model);
        Task UpdateAsync(SectionModel model);
        Task DeleteAsync(int id);
    }
}
