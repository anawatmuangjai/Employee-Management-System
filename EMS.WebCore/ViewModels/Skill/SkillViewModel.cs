using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Skill
{
    public class SkillViewModel
    {
        public IEnumerable<SkillModel> Skills { get; set; }
    }
}
