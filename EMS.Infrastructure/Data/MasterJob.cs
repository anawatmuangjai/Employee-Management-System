namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterJob")]
    public partial class MasterJob
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MasterJob()
        {
            EmployeeStates = new HashSet<EmployeeState>();
            MasterJobFunctions = new HashSet<MasterJobFunction>();
        }

        [Key]
        public int JobID { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        [StringLength(100)]
        public string JobDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeState> EmployeeStates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MasterJobFunction> MasterJobFunctions { get; set; }
    }
}
