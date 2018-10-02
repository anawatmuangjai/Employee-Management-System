using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IAccountAuthorityService
    {
        Task<AccountAuthorityModel> GetByIdAsync(int id);
        Task<List<AccountAuthorityModel>> GetAllAsync();
        Task AddAsync(AccountAuthorityModel model);
    }
}
