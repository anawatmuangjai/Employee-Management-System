using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Shift
{
    public class ShiftViewModel
    {
        public IEnumerable<ShiftModel> Shifts { get; set; }
    }
}
