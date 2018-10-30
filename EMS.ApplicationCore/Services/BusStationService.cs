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

        public async Task<List<BusStationModel>> GetByRouteIdAsync(int routeId)
        {
            var busStations = await _repository.GetAsync(x => x.RouteId == routeId);
            return _mapper.Map<List<MasterBusStation>, List<BusStationModel>>(busStations);
        }

        public async Task AddAsync(BusStationModel model)
        {
            var busStation = new MasterBusStation
            {
                RouteId = model.RouteId,
                BusStationName = model.BusStationName,
                BusStationCode = model.BusStationCode,
                TimeInDay = model.TimeInDay,
                TimeInNight = model.TimeInNight,
            };

            await _repository.AddAsync(busStation);
        }

        public async Task UpdateAsync(BusStationModel model)
        {
            var busStation = await _repository.GetByIdAsync(model.BusStationId);

            busStation.RouteId = model.RouteId;
            busStation.BusStationName = model.BusStationName;
            busStation.BusStationCode = model.BusStationCode;
            busStation.TimeInDay = model.TimeInDay;
            busStation.TimeInNight = model.TimeInNight;

            await _repository.UpdateAsync(busStation);
        }

        public async Task DeleteAsync(int id)
        {
            var busStation = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(busStation);
        }
    }
}
