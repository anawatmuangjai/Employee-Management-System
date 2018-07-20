using System;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMS.Persistance.Context
{
    public partial class EmployeeContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }
        public virtual DbSet<EmployeeImage> EmployeeImage { get; set; }
        public virtual DbSet<EmployeeLocation> EmployeeLocation { get; set; }
        public virtual DbSet<EmployeePassword> EmployeePassword { get; set; }
        public virtual DbSet<EmployeeState> EmployeeState { get; set; }
        public virtual DbSet<MasterBusStation> MasterBusStation { get; set; }
        public virtual DbSet<MasterDepartment> MasterDepartment { get; set; }
        public virtual DbSet<MasterEducationDegree> MasterEducationDegree { get; set; }
        public virtual DbSet<MasterEducationMajor> MasterEducationMajor { get; set; }
        public virtual DbSet<MasterJobFunction> MasterJobFunction { get; set; }
        public virtual DbSet<MasterJobTitle> MasterJobTitle { get; set; }
        public virtual DbSet<MasterLevel> MasterLevel { get; set; }
        public virtual DbSet<MasterLocation> MasterLocation { get; set; }
        public virtual DbSet<MasterSection> MasterSection { get; set; }
        public virtual DbSet<MasterShift> MasterShift { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=E4M;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.GlobalId)
                    .HasName("UQ__Employee__A50E89936477ECF3")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AvailableFlag).HasDefaultValueSql("('1')");

                entity.Property(e => e.BirthDate).HasColumnType("date");

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
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstNameThai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

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
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<EmployeeAddress>(entity =>
            {
                entity.Property(e => e.EmployeeAddressId).HasColumnName("EmployeeAddressID");

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

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAddress)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeAdress_Employee_EmployeeID");
            });

            modelBuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.Property(e => e.EmployeeEducationId).HasColumnName("EmployeeEducationID");

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastEducation).HasDefaultValueSql("('1')");

                entity.Property(e => e.MajorId).HasColumnName("MajorID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeEducation)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.EmployeeEducation)
                    .HasForeignKey(d => d.MajorId);
            });

            modelBuilder.Entity<EmployeeImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeImage)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<EmployeeLocation>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.EmployeeId });

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLocation)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EmployeeLocation)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<EmployeePassword>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false)
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

            modelBuilder.Entity<EmployeeState>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BusStationId).HasColumnName("BusStationID");

                entity.Property(e => e.ChangedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.BusStation)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.BusStationId)
                    .HasConstraintName("FK_EmployeeState_MasterBusStation");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeeState)
                    .HasForeignKey<EmployeeState>(d => d.EmployeeId);

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.JobTitleId);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.LevelId);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.SectionId);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.ShiftId);
            });

            modelBuilder.Entity<MasterBusStation>(entity =>
            {
                entity.HasKey(e => e.BusStationId);

                entity.HasIndex(e => e.BusStationName)
                    .HasName("UQ__MasterBu__948825A80A9D95DB")
                    .IsUnique();

                entity.HasIndex(e => e.BusStationRoute)
                    .HasName("UQ__MasterBu__1AA3675007C12930")
                    .IsUnique();

                entity.Property(e => e.BusStationId).HasColumnName("BusStationID");

                entity.Property(e => e.BusStationRoute)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
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

            modelBuilder.Entity<MasterEducationDegree>(entity =>
            {
                entity.HasKey(e => e.DegreeId);

                entity.HasIndex(e => e.DegreeName)
                    .HasName("UQ__MasterEd__9C9AC10B17F790F9")
                    .IsUnique();

                entity.HasIndex(e => e.DegreeNameThai)
                    .HasName("UQ__MasterEd__09BC69B3151B244E")
                    .IsUnique();

                entity.Property(e => e.DegreeId).HasColumnName("DegreeID");

                entity.Property(e => e.DegreeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DegreeNameThai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MasterEducationMajor>(entity =>
            {
                entity.HasKey(e => e.MajorId);

                entity.HasIndex(e => e.MajorNameThai)
                    .HasName("UQ__MasterEd__435581B51EA48E88")
                    .IsUnique();

                entity.HasIndex(e => e.MarjorName)
                    .HasName("UQ__MasterEd__42EA55B92180FB33")
                    .IsUnique();

                entity.Property(e => e.MajorId).HasColumnName("MajorID");

                entity.Property(e => e.DegreeId).HasColumnName("DegreeID");

                entity.Property(e => e.MajorNameThai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MarjorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.MasterEducationMajor)
                    .HasForeignKey(d => d.DegreeId);
            });

            modelBuilder.Entity<MasterJobFunction>(entity =>
            {
                entity.HasKey(e => e.JobFunctionId);

                entity.Property(e => e.JobFunctionId).HasColumnName("JobFunctionID");

                entity.Property(e => e.FunctionDescription).HasMaxLength(100);

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.MasterJobFunction)
                    .HasForeignKey(d => d.JobTitleId);
            });

            modelBuilder.Entity<MasterJobTitle>(entity =>
            {
                entity.HasKey(e => e.JobTitleId);

                entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");

                entity.Property(e => e.JobDescription).HasMaxLength(100);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50);
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

            modelBuilder.Entity<MasterLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationImagePath).HasMaxLength(150);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
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
        }
    }
}
