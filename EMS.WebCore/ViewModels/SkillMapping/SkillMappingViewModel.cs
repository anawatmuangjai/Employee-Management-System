using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.SkillMapping
{
    public class SkillMappingViewModel
    {
        public EmployeeModel FirstEmployee { get; set; }
        public EmployeeModel SecondEmployee { get; set; }
        public IEnumerable<EmployeeSkillModel> FirstEmployeeSkills { get; set; }
        public IEnumerable<EmployeeSkillModel> SecondEmployeeSkills { get; set; }
    }
}
