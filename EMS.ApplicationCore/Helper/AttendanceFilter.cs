using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.ApplicationCore.Helper
{
    public class AttendanceFilter : EmployeeFilter
    {
        public string AttendanceDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsLate { get; set; }
    }
}
