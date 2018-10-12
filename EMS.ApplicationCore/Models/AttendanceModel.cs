using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class AttendanceModel
    {
        public string EmployeeId { get; set; }
        public string Title { get; set; }
        public string EmployeeType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstNameThai { get; set; }
        public string LastNameThai { get; set; }
        public string LevelCode { get; set; }
        public string ShiftName { get; set; }
        public string DepartmentCode { get; set; }
        public string SectionName { get; set; }
        public string JobTitle { get; set; }
        public string FunctionName { get; set; }
        public string RouteName { get; set; }
        public string BusStationName { get; set; }
        public string PassCode { get; set; }
        public string ScanInTime { get; set; }
        public string ScanOutTime { get; set; }
        public string AttendanceDate { get; set; }
        public int ShiftId { get; set; }
        public int PositionId { get; set; }
        public int JobFunctionId { get; set; }
        public int SectionId { get; set; }
        public int DepartmentId { get; set; }
    }
}
