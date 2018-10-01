using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterBusStation : BaseEntity
    {
        public MasterBusStation()
        {
            EmployeeState = new HashSet<EmployeeState>();
        }

        public int BusStationId { get; set; }
        public int RouteId { get; set; }
        public string BusStationName { get; set; }
        public string BusStationCode { get; set; }
        public TimeSpan TimeInDay { get; set; }
        public TimeSpan TimeInNight { get; set; }

        public MasterRoute Route { get; set; }
        public ICollection<EmployeeState> EmployeeState { get; set; }
    }
}
