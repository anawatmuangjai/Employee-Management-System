namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skill")]
    public partial class Skill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
            JobFunctionSkills = new HashSet<JobFunctionSkill>();
        }

        public int SkillID { get; set; }

        public int SkillGroupID { get; set; }

        [Required]
        [StringLength(100)]
        public string SKillName { get; set; }

        public DateTime ChangedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobFunctionSkill> JobFunctionSkills { get; set; }

        public virtual SkillGroup SkillGroup { get; set; }
    }
}
