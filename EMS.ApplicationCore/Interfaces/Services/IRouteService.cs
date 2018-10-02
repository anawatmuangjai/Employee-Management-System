using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IRouteService
    {
        Task<RouteModel> GetByIdAsync(int id);
        Task<List<RouteModel>> GetAllAsync();
        Task AddAsync(RouteModel model);
        Task UpdateAsync(RouteModel model);
        Task DeleteAsync(int id);
    }
}
