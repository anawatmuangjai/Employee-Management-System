﻿using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class EmployeePassword
    {
        public int EmployeeId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime ChangedDate { get; set; }

        public Employee Employee { get; set; }
    }
}