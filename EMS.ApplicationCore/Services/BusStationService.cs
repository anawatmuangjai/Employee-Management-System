using AutoMapper;
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
    public class BusStationService : IBusStationService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterBusStation> _repository;

        public BusStationService(IAsyncRepository<MasterBusStation> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterBusStation, BusStationModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<BusStationModel> GetByIdAsync(int id)
        {
            var busStation = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterBusStation, BusStationModel>(busStation);
        }

        public async Task<List<BusStationModel>> GetAllAsync()
        {
            var busStation = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterBusStation>, List<BusStationModel>>(busStation);
        }

        public async Task<List<BusStationModel>> GetByNameAsync(string name)
        {
            var busStation = await _repository.GetAsync(x => x.BusStationName == name);
            return _mapper.Map<List<MasterBusStation>, List<BusStationModel>>(busStation);
        }

        public async Task AddAsync(BusStationModel model)
        {
            var busStation = new MasterBusStation
            {
                BusStationName = model.BusStationName,
                BusStationRoute = model.BusStationRoute,
            };

            await _repository.AddAsync(busStation);
        }

        public async Task UpdateAsync(BusStationModel model)
        {
            var busStation = await _repository.GetByIdAsync(model.BusStationId);

            busStation.BusStationName = model.BusStationName;
            busStation.BusStationRoute = model.BusStationRoute;

            await _repository.UpdateAsync(busStation);
        }

        public async Task DeleteAsync(int id)
        {
            var busStation = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(busStation);
        }
    }
}
