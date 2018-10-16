using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeSkillModel
    {
        public string EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int SkillLevel { get; set; }

        public EmployeeModel Employee { get; set; }
        public SkillModel Skill { get; set; }
    }
}
