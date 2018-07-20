using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class BusStationPresenter : IBusStationPresenter
    {
        private readonly IBusStationView _view;
        private readonly IBusStationService _busStationService;

        public BusStationPresenter(IBusStationView view, IBusStationService busStationService)
        {
            _view = view;
            _view.Presenter = this;
            _busStationService = busStationService;
        }

        public IBusStationView GetView()
        {
            return _view;
        }

        public async Task ViewAllAsync()
        {
            _view.BusStations = await _busStationService.GetAllAsync();
        }

        public async Task SearchAsync()
        {
            _view.BusStations = await _busStationService.GetByNameAsync(_view.Filter);
        }

        public async Task SaveAsync()
        {
            var busStation = new BusStationModel
            {
                BusStationId = _view.BusStationId,
                BusStationName = _view.BusStationName,
                BusStationRoute = _view.BusStationRoute
            };

            if (busStation.BusStationId > 0)
                await _busStationService.UpdateAsync(busStation);
            else
                await _busStationService.AddAsync(busStation);
        }

        public async Task DeleteAsync()
        {
            await _busStationService.DeleteAsync(_view.SelectedBusStation);
        }
    }
}
