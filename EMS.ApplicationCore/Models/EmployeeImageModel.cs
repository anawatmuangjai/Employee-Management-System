﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class EmployeeImageModel
    {
        public int ImageId { get; set; }
        public string EmployeeId { get; set; }
        public byte[] Images { get; set; }
    }
}
