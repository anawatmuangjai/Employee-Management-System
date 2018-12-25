using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.SkillMapping
{
    public class SkillMappingViewModel
    {
        public string FirstProfileImage { get; set; }
        public string SecondProfileImage { get; set; }
        public EmployeeModel FirstEmployee { get; set; }
        public EmployeeModel SecondEmployee { get; set; }
        public IEnumerable<EmployeeSkillModel> FirstEmployeeSkills { get; set; }
        public IEnumerable<EmployeeSkillModel> SecondEmployeeSkills { get; set; }
    }
}