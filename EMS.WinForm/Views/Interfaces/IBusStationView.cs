using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System.Collections.Generic;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IBusStationView
    {
        int BusStationId { get; set; }
        string BusStationName { get; set; }
        string BusStationRoute { get; set; }
        string Filter { get; set; }
        BusStationModel SelectedBusStation { get; set; }
        IList<BusStationModel> BusStations { set; }
        BusStationPresenter Presenter { set; }
    }
}
