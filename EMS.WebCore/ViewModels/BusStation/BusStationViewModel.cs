using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.BusStation
{
    public class BusStationViewModel
    {
        public IEnumerable<BusStationModel> BusStations { get; set; }
    }
}