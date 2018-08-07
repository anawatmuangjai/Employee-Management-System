using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeePassword : BaseEntity
    {
        public string EmployeeId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime ChangedDate { get; set; }

        public Employee Employee { get; set; }
    }
}
