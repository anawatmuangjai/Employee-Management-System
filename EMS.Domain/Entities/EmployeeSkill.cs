using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int SkillLevelId { get; set; }
        public DateTime ChangedDate { get; set; }

        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
        public SkillLevel SkillLevel { get; set; }
    }
}
