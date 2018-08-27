using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Profile
{
    public class ProfileEditViewModel
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public int ShiftId { get; set; }
        public int JobTitleId { get; set; }
        public int JobFunctionId { get; set; }
        public int LevelId { get; set; }
        public int BusStationId { get; set; }
        public DateTime JoinDate { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Sections { get; set; }
        public IEnumerable<SelectListItem> Shifts { get; set; }
        public IEnumerable<SelectListItem> JobTitles { get; set; }
        public IEnumerable<SelectListItem> JobFunctions { get; set; }
        public IEnumerable<SelectListItem> JobLevels { get; set; }
        public IEnumerable<SelectListItem> BusStations { get; set; }
    }
}
