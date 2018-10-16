using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.ShiftCalendar
{
    public class ShiftCalendarViewModel
    {
        public IEnumerable<ShiftCalendarModel> ShiftCalendars { get; set; }
    }
}
