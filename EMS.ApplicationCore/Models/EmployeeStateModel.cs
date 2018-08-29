using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeStateModel
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

        public BusStationModel BusStation { get; set; }
        public DepartmentModel Department { get; set; }
        public EmployeeModel Employee { get; set; }
        public JobFunctionModel JobFunction { get; set; }
        public EmployeeLevelModel Level { get; set; }
        public JobPositionModel Position { get; set; }
        public SectionModel Section { get; set; }
        public ShiftModel Shift { get; set; }
    }
}
