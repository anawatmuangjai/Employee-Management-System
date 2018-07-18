using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class Employee : BaseEntity
    {
        public Employee()
        {
            EmployeeDetail = new HashSet<EmployeeDetail>();
            EmployeeEducation = new HashSet<EmployeeEducation>();
            EmployeeImage = new HashSet<EmployeeImage>();
            EmployeeSkill = new HashSet<EmployeeSkill>();
        }

        public int EmployeeId { get; set; }
        public string GlobalId { get; set; }
        public string CardId { get; set; }
        public string EmployeeType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstNameThai { get; set; }
        public string LastNameThai { get; set; }
        public string Gender { get; set; }
        public bool? AvailableFlag { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime ChangedDate { get; set; }

        public EmployeePassword EmployeePassword { get; set; }
        public EmployeeState EmployeeState { get; set; }
        public ICollection<EmployeeDetail> EmployeeDetail { get; set; }
        public ICollection<EmployeeEducation> EmployeeEducation { get; set; }
        public ICollection<EmployeeImage> EmployeeImage { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkill { get; set; }
    }
}
