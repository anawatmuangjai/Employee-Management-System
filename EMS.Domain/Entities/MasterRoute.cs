using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterRoute : BaseEntity
    {
        public MasterRoute()
        {
            MasterBusStation = new HashSet<MasterBusStation>();
        }

        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteCode { get; set; }

        public ICollection<MasterBusStation> MasterBusStation { get; set; }
    }
}
