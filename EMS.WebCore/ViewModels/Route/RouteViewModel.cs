using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Route
{
    public class RouteViewModel
    {
        public IEnumerable<RouteModel> Routes { get; set; }
    }
}