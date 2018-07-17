namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterJobFunction")]
    public partial class MasterJobFunction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MasterJobFunction()
        {
            JobFunctionSkills = new HashSet<JobFunctionSkill>();
        }

        [Key]
        public int JobFunctionID { get; set; }

        public int JobID { get; set; }

        [Required]
        [StringLength(100)]
        public string FunctionName { get; set; }

        [StringLength(100)]
        public string FunctionDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobFunctionSkill> JobFunctionSkills { get; set; }

        public virtual MasterJob MasterJob { get; set; }
    }
}
