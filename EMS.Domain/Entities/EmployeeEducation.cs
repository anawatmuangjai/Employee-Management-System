using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeEducation : BaseEntity
    {
        public int EmployeeEducationId { get; set; }
        public string EmployeeId { get; set; }
        public int MajorId { get; set; }
        public bool? LastEducation { get; set; }
        public DateTime ChangedDate { get; set; }

        public Employee Employee { get; set; }
        public MasterEducationMajor Major { get; set; }
    }
}
