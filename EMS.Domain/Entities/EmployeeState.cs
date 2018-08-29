using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeState : BaseEntity
    {
        public string EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public byte ShiftId { get; set; }
        public int LevelId { get; set; }
        public int PositionId { get; set; }
        public int JobFunctionId { get; set; }
        public int BusStationId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ChangedDate { get; set; }

        public MasterBusStation BusStation { get; set; }
        public MasterDepartment Department { get; set; }
        public Employee Employee { get; set; }
        public MasterJobFunction JobFunction { get; set; }
        public MasterLevel Level { get; set; }
        public MasterJobPosition Position { get; set; }
        public MasterSection Section { get; set; }
        public MasterShift Shift { get; set; }
    }
}
