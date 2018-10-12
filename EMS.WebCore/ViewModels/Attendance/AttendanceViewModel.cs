using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Attendance
{
    public class AttendanceViewModel
    {
        public string ProfileImage { get; set; }
        public EmployeeModel Employee { get; set; }
        public AttendanceFilter FilterModel { get; set; }
        public IEnumerable<AttendanceModel> Attendances { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Sections { get; set; }
        public IEnumerable<SelectListItem> Shifts { get; set; }
        public IEnumerable<SelectListItem> Positions { get; set; }
        public IEnumerable<SelectListItem> JobFunctions { get; set; }
        public IEnumerable<SelectListItem> JobLevels { get; set; }
        public IEnumerable<SelectListItem> BusStations { get; set; }
    }
}
