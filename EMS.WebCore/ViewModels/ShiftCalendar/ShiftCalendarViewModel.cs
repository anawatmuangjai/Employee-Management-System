using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.ShiftCalendar
{
    public class ShiftCalendarViewModel
    {
        public IEnumerable<ShiftCalendarModel> ShiftCalendars { get; set; }
    }
}