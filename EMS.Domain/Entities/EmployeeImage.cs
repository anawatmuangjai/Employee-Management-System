using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeImage
    {
        public int ImageId { get; set; }
        public int EmployeeId { get; set; }
        public byte[] Images { get; set; }

        public Employee Employee { get; set; }
    }
}
