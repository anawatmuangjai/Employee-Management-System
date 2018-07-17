namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterSection")]
    public partial class MasterSection
    {
        [Key]
        public int SectionID { get; set; }

        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string SectionName { get; set; }

        [StringLength(10)]
        public string SectionCode { get; set; }

        public virtual MasterDepartment MasterDepartment { get; set; }
    }
}
