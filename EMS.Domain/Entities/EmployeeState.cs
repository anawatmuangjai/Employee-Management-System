using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeState
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public byte ShiftId { get; set; }
        public int JobId { get; set; }
        public int LevelId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ChangedDate { get; set; }

        public MasterDepartment Department { get; set; }
        public Employee Employee { get; set; }
        public MasterJob Job { get; set; }
        public MasterLevel Level { get; set; }
        public MasterShift Shift { get; set; }
    }
}
