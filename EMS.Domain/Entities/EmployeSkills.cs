using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeSkills : BaseEntity
    {
        public string EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int SkillLevel { get; set; }

        public Employee Employee { get; set; }
        public MasterSkill Skill { get; set; }
    }
}
