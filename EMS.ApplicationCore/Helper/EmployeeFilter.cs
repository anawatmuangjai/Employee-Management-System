using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Helper
{
    public class EmployeeFilter
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeGroup { get; set; }
        public int? SectionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ShiftId { get; set; }
        public int? PositionId { get; set; }
        public int? FunctionId { get; set; }
        public int? LevelId { get; set; }
        public bool? AvailableFlag { get; set; }
    }
}
