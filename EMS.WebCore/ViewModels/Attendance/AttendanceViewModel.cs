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
        public string EmployeeId { get; set; }
        public string SectionId { get; set; }
        public string DepartmentId { get; set; }
        public string ShiftId { get; set; }
        public string PositionId { get; set; }
        public string FunctionId { get; set; }
        public string ProfileImage { get; set; }
        public DateTime AttendanceDate { get; set; }
        public EmployeeModel Employee { get; set; }
        public AttendanceFilterModel FilterModel { get; set; }
        public IEnumerable<AttendanceModel> Attendances { get; set; }
    }
}
