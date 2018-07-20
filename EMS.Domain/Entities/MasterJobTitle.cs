using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterJobTitle : BaseEntity
    {
        public MasterJobTitle()
        {
            EmployeeState = new HashSet<EmployeeState>();
            MasterJobFunction = new HashSet<MasterJobFunction>();
        }

        public int JobTitleId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        public ICollection<EmployeeState> EmployeeState { get; set; }
        public ICollection<MasterJobFunction> MasterJobFunction { get; set; }
    }
}
