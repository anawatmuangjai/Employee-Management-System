using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.ShiftCalendar
{
    public class ShiftCalendarEditViewModel
    {
        public DateTime WorkDate { get; set; }
        public string WorkType { get; set; }
        public byte ShiftId { get; set; }

        public IEnumerable<SelectListItem> Shifts { get; set; }
    }
}
