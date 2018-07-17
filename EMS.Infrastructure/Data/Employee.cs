namespace EMS.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            EmployeeDetails = new HashSet<EmployeeDetail>();
            EmployeeEducations = new HashSet<EmployeeEducation>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
            EmployeeImages = new HashSet<EmployeeImage>();
        }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(30)]
        public string GlobalID { get; set; }

        [Required]
        [StringLength(50)]
        public string CardID { get; set; }

        [Required]
        [StringLength(2)]
        public string EmployeeType { get; set; }

        [Required]
        [StringLength(15)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstNameThai { get; set; }

        [Required]
        [StringLength(50)]
        public string LastNameThai { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        public bool AvailableFlag { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime ChangedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        public virtual EmployeeState EmployeeState { get; set; }

        public virtual EmployeePassword EmployeePassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeImage> EmployeeImages { get; set; }
    }
}
