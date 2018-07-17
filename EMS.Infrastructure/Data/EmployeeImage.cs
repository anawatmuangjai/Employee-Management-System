namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeImage")]
    public partial class EmployeeImage
    {
        [Key]
        public int ImageID { get; set; }

        public int EmployeeID { get; set; }

        public byte[] Images { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
