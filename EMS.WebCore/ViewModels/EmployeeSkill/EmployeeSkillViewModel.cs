using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.EmployeeSkill
{
    public class EmployeeSkillViewModel
    {
        public EmployeeModel Employee { get; set; }
        public IEnumerable<EmployeeSkillModel> EmployeeSkills { get; set; }
    }
}
