using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Route
{
    public class RouteViewModel
    {
        public IEnumerable<RouteModel> Routes { get; set; }
    }
}
