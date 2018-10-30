using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IBusStationService
    {
        Task<BusStationModel> GetByIdAsync(int id);
        Task<List<BusStationModel>> GetAllAsync();
        Task<List<BusStationModel>> GetByNameAsync(string name);
        Task<List<BusStationModel>> GetByRouteIdAsync(int routeId);
        Task AddAsync(BusStationModel model);
        Task UpdateAsync(BusStationModel model);
        Task DeleteAsync(int id);
    }
}
