using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IShiftService
    {
        Task<ShiftModel> GetByIdAsync(int id);
        Task<List<ShiftModel>> GetAllAsync();
        Task<List<ShiftModel>> GetByNameAsync(string name);
        Task AddAsync(ShiftModel model);
        Task UpdateAsync(ShiftModel model);
        Task DeleteAsync(int id);
    }
}
