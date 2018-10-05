using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.SkillType
{
    public class SkillTypeViewModel
    {
        public IEnumerable<SkillTypeModel> SkillTypes { get; set; }
    }
}
