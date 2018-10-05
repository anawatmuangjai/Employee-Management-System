using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.SkillGroup
{
    public class SkillGroupViewModel
    {
        public IEnumerable<SkillGroupModel> SkillGroups { get; set; }
    }
}
