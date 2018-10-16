using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class ShiftCalendarModel
    {
        public DateTime WorkDate { get; set; }
        public string WorkType { get; set; }
        public byte ShiftId { get; set; }

        public ShiftModel Shift { get; set; }
    }
}
