using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeDetailModel
    {
        public int EmployeeDetailId { get; set; }
        public int EmployeeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
