using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.ApplicationCore.Helper
{
    public class AttendanceFilter
    {
        public string EmployeeId { get; set; }
        public int? SectionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ShiftId { get; set; }
        public int? PositionId { get; set; }
        public int? FunctionId { get; set; }
        public string AttendanceDate { get; set; }
    }
}
