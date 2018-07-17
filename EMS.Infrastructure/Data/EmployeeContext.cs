namespace EMS.Infrastructure.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public virtual DbSet<EmployeeImage> EmployeeImages { get; set; }
        public virtual DbSet<EmployeePassword> EmployeePasswords { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<EmployeeState> EmployeeStates { get; set; }
        public virtual DbSet<JobFunctionSkill> JobFunctionSkills { get; set; }
        public virtual DbSet<MasterDepartment> MasterDepartments { get; set; }
        public virtual DbSet<MasterEducation> MasterEducations { get; set; }
        public virtual DbSet<MasterJob> MasterJobs { get; set; }
        public virtual DbSet<MasterJobFunction> MasterJobFunctions { get; set; }
        public virtual DbSet<MasterLevel> MasterLevels { get; set; }
        public virtual DbSet<MasterSection> MasterSections { get; set; }
        public virtual DbSet<MasterShift> MasterShifts { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillGroup> SkillGroups { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.GlobalID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CardID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeType)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.EmployeeState)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.EmployeePassword)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePassword>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePassword>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<MasterDepartment>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<MasterDepartment>()
                .Property(e => e.DepartmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<MasterLevel>()
                .Property(e => e.LevelName)
                .IsUnicode(false);

            modelBuilder.Entity<MasterLevel>()
                .Property(e => e.LevelCode)
                .IsUnicode(false);

            modelBuilder.Entity<MasterSection>()
                .Property(e => e.SectionCode)
                .IsUnicode(false);
        }
    }
}
