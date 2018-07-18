using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterEducation : BaseEntity
    {
        public MasterEducation()
        {
            EmployeeEducation = new HashSet<EmployeeEducation>();
        }

        public int EducationId { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }

        public ICollection<EmployeeEducation> EmployeeEducation { get; set; }
    }
}
