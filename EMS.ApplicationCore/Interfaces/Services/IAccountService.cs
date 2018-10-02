using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AccountModel> GetByIdAsync(int id);
        Task<AccountModel> GetByUserNameAsync(string username);
        Task<List<AccountModel>> GetAllAsync();
        Task<bool> ExistsAsync(string username);
        Task<AccountModel> AddAsync(AccountModel model);
        Task UpdateAsync(AccountModel model);
        Task DeleteAsync(int id);
    }
}
