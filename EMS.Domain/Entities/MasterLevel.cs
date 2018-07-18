using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterLevel : BaseEntity
    {
        public MasterLevel()
        {
            EmployeeState = new HashSet<EmployeeState>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public string LevelCode { get; set; }

        public ICollection<EmployeeState> EmployeeState { get; set; }
    }
}
