using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IAuthorityService
    {
        Task<AuthorityModel> GetByIdAsync(int id);
        Task<AuthorityModel> GetByNameAsync(string name);
        Task<List<AuthorityModel>> GetAllAsync();
        Task<bool> ExistsAsync(string name);
        Task AddAsync(AuthorityModel model);
        Task UpdateAsync(AuthorityModel model);
        Task DeleteAsync(int id);
    }
}
