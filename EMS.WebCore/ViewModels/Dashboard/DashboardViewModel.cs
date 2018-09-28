using EMS.ApplicationCore.Models;
using EMS.WebCore.Models.Dashboard;
using Microsoft.AspNetCore.Html;
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

        public IEnumerable<AttendanceModel> Attendances { get; set; }
        public IEnumerable<AttendanceShift> AttendanceByShift { get; set; }

        public HtmlString AttendancePercentValue { get; set; }

        public HtmlString AttendanceLevelLabel { get; set; }
        public HtmlString AttendanceLevelValue { get; set; }

        public HtmlString AttendanceChartLabel { get; set; }
        public HtmlString AttendanceChartValue { get; set; }

        public HtmlString DepartmentChartLabel { get; set; }
        public HtmlString DepartmentChartValue { get; set; }

        public HtmlString SectiobChartLabel { get; set; }
        public HtmlString SectiobChartValue { get; set; }

        public HtmlString TransportChartLabel { get; set; }
        public HtmlString TransportChartValue { get; set; }

    }
}
