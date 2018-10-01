using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeAccount : BaseEntity
    {
        public int AccountId { get; set; }
        public string EmployeeId { get; set; }

        public MasterAccount Account { get; set; }
        public Employee Employee { get; set; }
    }
}
