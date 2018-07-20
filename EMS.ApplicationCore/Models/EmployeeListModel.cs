using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeListModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeType { get; set; }
        public string GlobalId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstNameThai { get; set; }
        public string LastNameThai { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public byte[] Images { get; set; }
    }
}
