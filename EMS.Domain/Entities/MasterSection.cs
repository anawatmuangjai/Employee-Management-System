using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterSection : BaseEntity
    {
        public MasterSection()
        {
            MasterJobFunction = new HashSet<MasterJobFunction>();
        }

        public int SectionId { get; set; }
        public int DepartmentId { get; set; }
        public string SectionName { get; set; }
        public string SectionCode { get; set; }

        public MasterDepartment Department { get; set; }
        public ICollection<MasterJobFunction> MasterJobFunction { get; set; }
    }
}
