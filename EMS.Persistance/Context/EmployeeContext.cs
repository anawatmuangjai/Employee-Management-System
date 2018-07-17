using System;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMS.Persistance.Context
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetail { get; set; }
        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }
        public virtual DbSet<EmployeeImage> EmployeeImage { get; set; }
        public virtual DbSet<EmployeePassword> EmployeePassword { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public virtual DbSet<EmployeeState> EmployeeState { get; set; }
        public virtual DbSet<JobFunctionSkill> JobFunctionSkill { get; set; }
        public virtual DbSet<MasterDepartment> MasterDepartment { get; set; }
        public virtual DbSet<MasterEducation> MasterEducation { get; set; }
        public virtual DbSet<MasterJob> MasterJob { get; set; }
        public virtual DbSet<MasterJobFunction> MasterJobFunction { get; set; }
        public virtual DbSet<MasterLevel> MasterLevel { get; set; }
        public virtual DbSet<MasterSection> MasterSection { get; set; }
        public virtual DbSet<MasterShift> MasterShift { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillGroup> SkillGroup { get; set; }
        public virtual DbSet<SkillLevel> SkillLevel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=E4M;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.GlobalId)
                    .HasName("UQ__Employee__A50E8993483ECBE8")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.AvailableFlag)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("CardID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeType)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstNameThai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.GlobalId)
                    .IsRequired()
                    .HasColumnName("GlobalID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastNameThai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.Property(e => e.EmployeeDetailId).HasColumnName("EmployeeDetailID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDetail)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.Property(e => e.EmployeeEducationId).HasColumnName("EmployeeEducationID");

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EducationId).HasColumnName("EducationID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.LastEducation)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.EmployeeEducation)
                    .HasForeignKey(d => d.EducationId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeEducation)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<EmployeeImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeImage)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PersonImage_Person_PersonID");
            });

            modelBuilder.Entity<EmployeePassword>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChangedDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeePassword)
                    .HasForeignKey<EmployeePassword>(d => d.EmployeeId)
                    .HasConstraintName("FK_Password_Employee_EmployeeID");
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.SkillId, e.SkillLevelId });

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.SkillLevelId).HasColumnName("SkillLevelID");

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSkill)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.EmployeeSkill)
                    .HasForeignKey(d => d.SkillId);

                entity.HasOne(d => d.SkillLevel)
                    .WithMany(p => p.EmployeeSkill)
                    .HasForeignKey(d => d.SkillLevelId)
                    .HasConstraintName("FK_EmployeeSkill_SkillLevel_LevelID");
            });

            modelBuilder.Entity<EmployeeState>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeeState)
                    .HasForeignKey<EmployeeState>(d => d.EmployeeId);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.JobId);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.LevelId);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.ShiftId);
            });

            modelBuilder.Entity<JobFunctionSkill>(entity =>
            {
                entity.HasKey(e => new { e.JobFunctionId, e.SkillId });

                entity.Property(e => e.JobFunctionId).HasColumnName("JobFunctionID");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Require)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.JobFunction)
                    .WithMany(p => p.JobFunctionSkill)
                    .HasForeignKey(d => d.JobFunctionId);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.JobFunctionSkill)
                    .HasForeignKey(d => d.SkillId);
            });

            modelBuilder.Entity<MasterDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId);

                entity.Property(e => e.EducationId).HasColumnName("EducationID");

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Major)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MasterJob>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.JobDescription).HasMaxLength(100);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MasterJobFunction>(entity =>
            {
                entity.HasKey(e => e.JobFunctionId);

                entity.Property(e => e.JobFunctionId).HasColumnName("JobFunctionID");

                entity.Property(e => e.FunctionDescription).HasMaxLength(100);

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.MasterJobFunction)
                    .HasForeignKey(d => d.JobId);
            });

            modelBuilder.Entity<MasterLevel>(entity =>
            {
                entity.HasKey(e => e.LevelId);

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.LevelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LevelName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterSection>(entity =>
            {
                entity.HasKey(e => e.SectionId);

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.SectionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.MasterSection)
                    .HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<MasterShift>(entity =>
            {
                entity.HasKey(e => e.ShiftId);

                entity.Property(e => e.ShiftId)
                    .HasColumnName("ShiftID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SkillGroupId).HasColumnName("SkillGroupID");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasColumnName("SKillName")
                    .HasMaxLength(100);

                entity.HasOne(d => d.SkillGroup)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.SkillGroupId);
            });

            modelBuilder.Entity<SkillGroup>(entity =>
            {
                entity.Property(e => e.SkillGroupId).HasColumnName("SkillGroupID");

                entity.Property(e => e.SkillGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.Property(e => e.SkillLevelId).HasColumnName("SkillLevelID");

                entity.Property(e => e.SkillLevelName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
