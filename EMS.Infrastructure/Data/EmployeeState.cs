namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeState")]
    public partial class EmployeeState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        public int DepartmentID { get; set; }

        public byte ShiftID { get; set; }

        public int JobID { get; set; }

        public int LevelID { get; set; }

        public DateTime JoinDate { get; set; }

        public DateTime ChangedDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual MasterDepartment MasterDepartment { get; set; }

        public virtual MasterJob MasterJob { get; set; }

        public virtual MasterLevel MasterLevel { get; set; }

        public virtual MasterShift MasterShift { get; set; }
    }
}
