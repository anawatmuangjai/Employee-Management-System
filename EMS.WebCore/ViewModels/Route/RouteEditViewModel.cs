﻿using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.Route
{
    public class RouteEditViewModel
    {
        public int RouteId { get; set; }

        [Required, StringLength(50)]
        public string RouteName { get; set; }

        [Required, StringLength(50)]
        public string RouteCode { get; set; }
    }
}