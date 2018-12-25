using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Level
{
    public class LevelViewModel
    {
        public IEnumerable<EmployeeLevelModel> EmployeeLevels { get; set; }
    }
}