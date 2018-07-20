using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterEducationMajor : BaseEntity
    {
        public MasterEducationMajor()
        {
            EmployeeEducation = new HashSet<EmployeeEducation>();
        }

        public int MajorId { get; set; }
        public int DegreeId { get; set; }
        public string MarjorName { get; set; }
        public string MajorNameThai { get; set; }

        public MasterEducationDegree Degree { get; set; }
        public ICollection<EmployeeEducation> EmployeeEducation { get; set; }
    }
}
