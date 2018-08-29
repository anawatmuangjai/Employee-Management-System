using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterJobPosition : BaseEntity
    {
        public MasterJobPosition()
        {
            EmployeeState = new HashSet<EmployeeState>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string PositionCode { get; set; }

        public ICollection<EmployeeState> EmployeeState { get; set; }
    }
}
