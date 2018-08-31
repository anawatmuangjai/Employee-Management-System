using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Models
{
    public class AttendanceFilterModel
    {
        public string EmployeeId { get; set; }
        public string SectionId { get; set; }
        public string DepartmentId { get; set; }
        public string ShiftId { get; set; }
        public string PositionId { get; set; }
        public string FunctionId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Sections { get; set; }
        public IEnumerable<SelectListItem> Shifts { get; set; }
        public IEnumerable<SelectListItem> Positions { get; set; }
        public IEnumerable<SelectListItem> JobFunctions { get; set; }
        public IEnumerable<SelectListItem> JobLevels { get; set; }
        public IEnumerable<SelectListItem> BusStations { get; set; }
    }
}
