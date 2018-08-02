using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Employee
{
    public class RegisterEmployeeViewModel
    {
        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string GlobalId { get; set; }

        [Required]
        public string CardId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Title { get; set; }

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
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public int DepartmentId { get; set; }

        public int SectionId { get; set; }

        public byte ShiftId { get; set; }

        public int JobTitleId { get; set; }

        public int LevelId { get; set; }

        public int BusStationId { get; set; }

        public DateTime JoinDate { get; set; }

        public string HomeAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public IEnumerable<SelectListItem> EmployeeTypes { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

        public IEnumerable<SelectListItem> Sections { get; set; }

        public IEnumerable<SelectListItem> Levels { get; set; }

        public IEnumerable<SelectListItem> JobTitles { get; set; }

        public IEnumerable<SelectListItem> Shifts { get; set; }

    }
}
