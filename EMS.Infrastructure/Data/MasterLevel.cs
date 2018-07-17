namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterLevel")]
    public partial class MasterLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MasterLevel()
        {
            EmployeeStates = new HashSet<EmployeeState>();
        }

        [Key]
        public int LevelID { get; set; }

        [Required]
        [StringLength(30)]
        public string LevelName { get; set; }

        [Required]
        [StringLength(10)]
        public string LevelCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeState> EmployeeStates { get; set; }
    }
}
