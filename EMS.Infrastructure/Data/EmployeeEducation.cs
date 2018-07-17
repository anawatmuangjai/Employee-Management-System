namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeEducation")]
    public partial class EmployeeEducation
    {
        public int EmployeeEducationID { get; set; }

        public int EmployeeID { get; set; }

        public int EducationID { get; set; }

        public bool LastEducation { get; set; }

        public DateTime ChangedDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual MasterEducation MasterEducation { get; set; }
    }
}
