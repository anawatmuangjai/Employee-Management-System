using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeAddress : BaseEntity
    {
        public int EmployeeAddressId { get; set; }
        public string EmployeeId { get; set; }
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ChangedDate { get; set; }

        public Employee Employee { get; set; }
    }
}
