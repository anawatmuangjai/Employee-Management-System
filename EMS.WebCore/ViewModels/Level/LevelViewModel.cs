using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Level
{
    public class LevelViewModel
    {
        public IEnumerable<EmployeeLevelModel> EmployeeLevels { get; set; }

    }
}
