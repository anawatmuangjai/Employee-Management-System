using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeState : BaseEntity
    {
        public string EmployeeId { get; set; }
        public int SectionId { get; set; }
        public byte ShiftId { get; set; }
        public int JobTitleId { get; set; }
        public int LevelId { get; set; }
        public int BusStationId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ChangedDate { get; set; }

        public MasterBusStation BusStation { get; set; }
        public Employee Employee { get; set; }
        public MasterJobTitle JobTitle { get; set; }
        public MasterLevel Level { get; set; }
        public MasterSection Section { get; set; }
        public MasterShift Shift { get; set; }
    }
}
