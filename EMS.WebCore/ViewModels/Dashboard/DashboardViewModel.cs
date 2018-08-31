using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int CountTotalEmployee { get; set; }
        public int CountActiveWork { get; set; }
        public int CountAbsent { get; set; }
        public string PercentAbsent { get; set; }
    }
}
