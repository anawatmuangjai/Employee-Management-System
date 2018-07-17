using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Dtos
{
    public class SectionDto
    {
        public int SectionID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string SectionCode { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
