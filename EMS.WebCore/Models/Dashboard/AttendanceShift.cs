using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Models.Dashboard
{
    public class AttendanceShift
    {
        public string ShiftName { get; set; }
        public int TotalEmployee { get; set; }
        public int ActiveEmployee { get; set; }
    }
}
