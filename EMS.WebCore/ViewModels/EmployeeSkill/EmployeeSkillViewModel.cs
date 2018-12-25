using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.EmployeeSkill
{
    public class EmployeeSkillViewModel
    {
        public EmployeeModel Employee { get; set; }
        public IEnumerable<EmployeeSkillModel> EmployeeSkills { get; set; }
    }
}