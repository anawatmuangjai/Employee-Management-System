using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeEducation
    {
        public int EmployeeEducationId { get; set; }
        public int EmployeeId { get; set; }
        public int EducationId { get; set; }
        public bool? LastEducation { get; set; }
        public DateTime ChangedDate { get; set; }

        public MasterEducation Education { get; set; }
        public Employee Employee { get; set; }
    }
}
