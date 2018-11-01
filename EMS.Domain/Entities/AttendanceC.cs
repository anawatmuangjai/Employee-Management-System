using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class AttendanceC : BaseEntity
    {
        public long Id { get; set; }
        public string EmployeeId { get; set; }
        public string WorkDate { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string PassCode { get; set; }
        public string WorkShift { get; set; }
        public decimal WorkDay { get; set; }
        public byte Ot15 { get; set; }
        public byte Ot3 { get; set; }
        public short LateMin { get; set; }
    }
}
