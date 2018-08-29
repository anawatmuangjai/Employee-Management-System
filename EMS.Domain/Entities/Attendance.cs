using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class Attendance : BaseEntity
    {
        public long AttendanceId { get; set; }
        public string EmployeeId { get; set; }
        public string PassTime { get; set; }
        public string PassCode { get; set; }
        public string Location { get; set; }
        public bool NewFlag { get; set; }

        public Employee Employee { get; set; }
    }
}
