namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobFunctionSkill")]
    public partial class JobFunctionSkill
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobFunctionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillID { get; set; }

        public bool Require { get; set; }

        public DateTime ChangedDate { get; set; }

        public virtual MasterJobFunction MasterJobFunction { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
