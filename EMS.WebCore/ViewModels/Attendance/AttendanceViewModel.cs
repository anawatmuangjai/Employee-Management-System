using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Attendance
{
    public class AttendanceViewModel
    {
        public IEnumerable<AttendanceModel> Attendances { get; set; }
    }
}
