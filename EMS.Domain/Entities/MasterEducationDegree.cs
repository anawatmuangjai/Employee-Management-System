using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterEducationDegree : BaseEntity
    {
        public MasterEducationDegree()
        {
            MasterEducationMajor = new HashSet<MasterEducationMajor>();
        }

        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public string DegreeNameThai { get; set; }

        public ICollection<MasterEducationMajor> MasterEducationMajor { get; set; }
    }
}
