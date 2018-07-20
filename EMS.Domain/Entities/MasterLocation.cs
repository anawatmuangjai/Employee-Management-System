using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterLocation : BaseEntity
    {
        public MasterLocation()
        {
            EmployeeLocation = new HashSet<EmployeeLocation>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationImagePath { get; set; }
        public byte[] LocationImage { get; set; }

        public ICollection<EmployeeLocation> EmployeeLocation { get; set; }
    }
}
