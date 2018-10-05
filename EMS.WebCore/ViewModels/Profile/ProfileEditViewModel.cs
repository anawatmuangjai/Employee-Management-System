using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Profile
{
    public class ProfileEditViewModel
    {
        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string GlobalId { get; set; }

        [Required]
        public string CardId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TitleThai { get; set; }

        [Required]
        public string EmployeeType { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstNameThai { get; set; }

        [Required]
        public string LastNameThai { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public string Hand { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string HireType { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public int DepartmentId { get; set; }

        public int SectionId { get; set; }

        public int JobFunctionId { get; set; }

        public int JobPositionId { get; set; }

        public int ShiftId { get; set; }

        public int LevelId { get; set; }

        public int RouteId { get; set; }

        public int BusStationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public int EmployeeAddressId { get; set; }

        public string HomeAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public int ImageId { get; set; }

        public IFormFile EmployeeImage { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

        //public IEnumerable<SelectListItem> Sections { get; set; }

        public IEnumerable<SelectListItem> Shifts { get; set; }

        public IEnumerable<SelectListItem> JobPosition { get; set; }

        //public IEnumerable<SelectListItem> JobFunctions { get; set; }

        public IEnumerable<SelectListItem> JobLevels { get; set; }

        public IEnumerable<SelectListItem> Routes { get; set; }

        public IEnumerable<SelectListItem> BusStations { get; set; }
    }
}
