﻿using System;

namespace EMS.WebCore.ViewModels.Shift
{
    public class ShiftEditViewModel
    {
        public byte ShiftId { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}