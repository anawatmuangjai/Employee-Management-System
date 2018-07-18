using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeStateModel
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public byte ShiftId { get; set; }
        public int JobId { get; set; }
        public int LevelId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
