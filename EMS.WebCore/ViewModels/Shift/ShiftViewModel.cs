using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Shift
{
    public class ShiftViewModel
    {
        public IEnumerable<ShiftModel> Shifts { get; set; }
    }
}