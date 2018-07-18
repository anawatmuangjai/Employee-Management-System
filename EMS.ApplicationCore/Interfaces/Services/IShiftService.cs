using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IShiftService
    {
        Task<IEnumerable<ShiftModel>> GetAllAsync();
        Task AddAsync(ShiftModel model);
        Task UpdateAsync(ShiftModel model);
        Task DeleteAsync(int id);
    }
}
