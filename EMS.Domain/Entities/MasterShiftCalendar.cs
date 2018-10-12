using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterShiftCalendar : BaseEntity
    {
        public DateTime WorkDate { get; set; }
        public string WorkType { get; set; }
        public byte ShiftId { get; set; }

        public MasterShift Shift { get; set; }
    }
}
