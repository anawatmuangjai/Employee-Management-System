using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeLocation : BaseEntity
    {
        public int LocationId { get; set; }
        public string EmployeeId { get; set; }
        public int AxisX { get; set; }
        public int AxisY { get; set; }

        public Employee Employee { get; set; }
        public MasterLocation Location { get; set; }
    }
}
