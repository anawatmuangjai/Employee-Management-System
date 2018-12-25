using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.BusStation
{
    public class BusStationEditViewModel
    {
        public int BusStationId { get; set; }

        public int RouteId { get; set; }

        [Required, StringLength(50)]
        public string BusStationName { get; set; }

        [Required, StringLength(10)]
        public string BusStationCode { get; set; }

        public TimeSpan TimeInDay { get; set; }

        public TimeSpan TimeInNight { get; set; }

        public IEnumerable<SelectListItem> Routes { get; set; }
    }
}