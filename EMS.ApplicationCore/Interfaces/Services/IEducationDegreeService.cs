using EMS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEducationDegreeService
    {
        Task<List<EducationDegreeModel>> GetAllAsync();
        Task<List<EducationDegreeModel>> GetByNameAsync(string name);
        Task<EducationDegreeModel> AddAsync(EducationDegreeModel model);
        Task UpdateAsync(EducationDegreeModel model);
        Task DeleteAsync(int id);
    }
}
