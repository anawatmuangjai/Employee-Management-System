using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
