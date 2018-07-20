using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeStateModel
    {
        public string EmployeeId { get; set; }
        public int SectionId { get; set; }
        public byte ShiftId { get; set; }
        public int JobTitleId { get; set; }
        public int LevelId { get; set; }
        public int BusStationId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
