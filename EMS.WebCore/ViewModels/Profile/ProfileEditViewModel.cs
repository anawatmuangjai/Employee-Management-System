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
        public string EmployeeId { get; set; }

        public string GlobalId { get; set; }

        public string CardId { get; set; }

        public string Title { get; set; }

        public string TitleThai { get; set; }

        public string EmployeeType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FirstNameThai { get; set; }

        public string LastNameThai { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public int DepartmentId { get; set; }

        public int SectionId { get; set; }

        public int ShiftId { get; set; }

        public int JobPositionId { get; set; }

        public int JobFunctionId { get; set; }

        public int LevelId { get; set; }

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

        public IEnumerable<SelectListItem> Sections { get; set; }

        public IEnumerable<SelectListItem> Shifts { get; set; }

        public IEnumerable<SelectListItem> JobTitles { get; set; }

        public IEnumerable<SelectListItem> JobFunctions { get; set; }

        public IEnumerable<SelectListItem> JobLevels { get; set; }

        public IEnumerable<SelectListItem> BusStations { get; set; }
    }
}
