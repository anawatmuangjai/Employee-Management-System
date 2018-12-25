using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.Profile
{
    public class EmployeeInfoViewModel
    {
        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public int JobPositionId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int SectionId { get; set; }

        [Required]
        public int JobFunctionId { get; set; }

        [Required]
        public int ShiftId { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public int RouteId { get; set; }

        [Required]
        public int BusStationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public ProfileHeaderViewModel ProfileHeader { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

        public IEnumerable<SelectListItem> Shifts { get; set; }

        public IEnumerable<SelectListItem> JobPosition { get; set; }

        public IEnumerable<SelectListItem> JobLevels { get; set; }

        public IEnumerable<SelectListItem> Routes { get; set; }

        public IEnumerable<SelectListItem> BusStations { get; set; }
    }
}