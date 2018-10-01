using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeModel
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
        public decimal Height { get; set; }
        public string Hand { get; set; }
        public DateTime BirthDate { get; set; }
        public string HireType { get; set; }
        public DateTime HireDate { get; set; }
        public bool? AvailableFlag { get; set; }
        public DateTime ChangedDate { get; set; }

        public EmployeeStateModel EmployeeState { get; set; }
    }
}
