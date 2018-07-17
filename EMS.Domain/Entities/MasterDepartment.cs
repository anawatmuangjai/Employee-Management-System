using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterDepartment : BaseEntity
    {
        public MasterDepartment()
        {
            EmployeeState = new HashSet<EmployeeState>();
            MasterSection = new HashSet<MasterSection>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentGroup { get; set; }

        public ICollection<EmployeeState> EmployeeState { get; set; }
        public ICollection<MasterSection> MasterSection { get; set; }
    }
}
