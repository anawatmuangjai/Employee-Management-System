using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.BusStation
{
    public class BusStationViewModel
    {
        public IEnumerable<BusStationModel> BusStations { get; set; }
    }
}
