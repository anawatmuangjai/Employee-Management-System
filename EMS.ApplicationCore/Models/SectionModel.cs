using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class SectionModel
    {
        public int SectionId { get; set; }
        public int DepartmentId { get; set; }
        public string SectionName { get; set; }
        public string SectionCode { get; set; }
        public string DepartmentName { get; set; }

    }
}
