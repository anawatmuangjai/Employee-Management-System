using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface ISectionService
    {
        Task<IEnumerable<DepartmentModel>> GetAllDepartmentAsync();
        Task<IEnumerable<SectionModel>> GetAllSectionAsync();
        Task<IEnumerable<SectionModel>> GetByNameAsync(string name);
        Task AddAsync(SectionModel model);
        Task UpdateAsync(SectionModel model);
        Task DeleteAsync(int sectionId);
    }
}
