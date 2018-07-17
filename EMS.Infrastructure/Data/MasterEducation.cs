namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterEducation")]
    public partial class MasterEducation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MasterEducation()
        {
            EmployeeEducations = new HashSet<EmployeeEducation>();
        }

        [Key]
        public int EducationID { get; set; }

        [Required]
        [StringLength(50)]
        public string Degree { get; set; }

        [Required]
        [StringLength(50)]
        public string Major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
