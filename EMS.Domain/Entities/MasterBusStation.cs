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
        public string BusStationName { get; set; }
        public string BusStationRoute { get; set; }

        public ICollection<EmployeeState> EmployeeState { get; set; }
    }
}
