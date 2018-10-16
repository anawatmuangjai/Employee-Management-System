using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IShiftCalendarService
    {
        Task<ShiftCalendarModel> GetByDateAsync(DateTime date);
        Task<List<ShiftCalendarModel>> GetAllAsync();
        Task AddAsync(ShiftCalendarModel model);
        Task UpdateAsync(ShiftCalendarModel model);
    }
}
