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
    public class RouteService : IRouteService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterRoute> _routeRepository;

        public RouteService(IAsyncRepository<MasterRoute> routeRepository)
        {
            _routeRepository = routeRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterRoute, RouteModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<RouteModel> GetByIdAsync(int id)
        {
            var route = await _routeRepository.GetByIdAsync(id);
            return _mapper.Map<MasterRoute, RouteModel>(route);

        }

        public async Task<List<RouteModel>> GetAllAsync()
        {
            var routes = await _routeRepository.GetAllAsync();
            return _mapper.Map<List<MasterRoute>, List<RouteModel>>(routes);
        }

        public async Task AddAsync(RouteModel model)
        {
            var route = new MasterRoute
            {
                RouteName = model.RouteName,
                RouteCode = model.RouteCode
            };

            await _routeRepository.AddAsync(route);
        }

        public async Task UpdateAsync(RouteModel model)
        {
            var route = await _routeRepository.GetByIdAsync(model.RouteId);

            route.RouteName = model.RouteName;
            route.RouteCode = model.RouteCode;

            await _routeRepository.UpdateAsync(route);
        }

        public async Task DeleteAsync(int id)
        {
            var route = await _routeRepository.GetByIdAsync(id);
            await _routeRepository.DeleteAsync(route);
        }

    }
}
