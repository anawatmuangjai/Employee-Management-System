using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class BusStationModel
    {
        public int BusStationId { get; set; }
        public int RouteId { get; set; }
        public string BusStationName { get; set; }
        public string BusStationCode { get; set; }
        public TimeSpan TimeInDay { get; set; }
        public TimeSpan TimeInNight { get; set; }
    }
}
