using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class SkillLevel : BaseEntity
    {
        public SkillLevel()
        {
            EmployeeSkill = new HashSet<EmployeeSkill>();
        }

        public int SkillLevelId { get; set; }
        public string SkillLevelName { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkill { get; set; }
    }
}
