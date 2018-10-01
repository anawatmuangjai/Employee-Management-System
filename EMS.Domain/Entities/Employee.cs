using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class Employee : BaseEntity
    {
        public Employee()
        {
            EmployeSkills = new HashSet<EmployeSkills>();
            EmployeeAccount = new HashSet<EmployeeAccount>();
            EmployeeAddress = new HashSet<EmployeeAddress>();
            EmployeeEducation = new HashSet<EmployeeEducation>();
            EmployeeImage = new HashSet<EmployeeImage>();
            EmployeeLocation = new HashSet<EmployeeLocation>();
        }

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
        public decimal Height { get; set; }
        public string Hand { get; set; }
        public DateTime BirthDate { get; set; }
        public string HireType { get; set; }
        public DateTime HireDate { get; set; }
        public bool? AvailableFlag { get; set; }
        public DateTime ChangedDate { get; set; }

        public EmployeeState EmployeeState { get; set; }
        public ICollection<EmployeSkills> EmployeSkills { get; set; }
        public ICollection<EmployeeAccount> EmployeeAccount { get; set; }
        public ICollection<EmployeeAddress> EmployeeAddress { get; set; }
        public ICollection<EmployeeEducation> EmployeeEducation { get; set; }
        public ICollection<EmployeeImage> EmployeeImage { get; set; }
        public ICollection<EmployeeLocation> EmployeeLocation { get; set; }
    }
}
