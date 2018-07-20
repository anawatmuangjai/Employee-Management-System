using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class BusStationService : BaseService<BusStationModel, MasterBusStation, IAsyncRepository<MasterBusStation>>, IBusStationService
    {
        public BusStationService(IAsyncRepository<MasterBusStation> repository)
            : base(repository)
        {
        }

        public async Task<List<BusStationModel>> GetByNameAsync(string name)
        {
            var entities = await _repository.GetAsync(x => x.BusStationName.Contains(name));
            return _mapper.Map<List<MasterBusStation>, List<BusStationModel>>(entities);
        }
    }
}
