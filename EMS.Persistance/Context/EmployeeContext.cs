﻿using System;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMS.Persistance.Context
{
    public partial class EmployeeContext : DbContext
    {
        public virtual DbSet<AttendanceC> AttendanceC { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAccount> EmployeeAccount { get; set; }
        public virtual DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }
        public virtual DbSet<EmployeeImage> EmployeeImage { get; set; }
        public virtual DbSet<EmployeeLocation> EmployeeLocation { get; set; }
        public virtual DbSet<EmployeeState> EmployeeState { get; set; }
        public virtual DbSet<EmployeSkills> EmployeSkills { get; set; }
        public virtual DbSet<MasterAccount> MasterAccount { get; set; }
        public virtual DbSet<MasterAccountAuthority> MasterAccountAuthority { get; set; }
        public virtual DbSet<MasterAuthority> MasterAuthority { get; set; }
        public virtual DbSet<MasterBusStation> MasterBusStation { get; set; }
        public virtual DbSet<MasterDepartment> MasterDepartment { get; set; }
        public virtual DbSet<MasterEducationDegree> MasterEducationDegree { get; set; }
        public virtual DbSet<MasterEducationMajor> MasterEducationMajor { get; set; }
        public virtual DbSet<MasterJobFunction> MasterJobFunction { get; set; }
        public virtual DbSet<MasterJobPosition> MasterJobPosition { get; set; }
        public virtual DbSet<MasterLevel> MasterLevel { get; set; }
        public virtual DbSet<MasterLocation> MasterLocation { get; set; }
        public virtual DbSet<MasterLocationGroup> MasterLocationGroup { get; set; }
        public virtual DbSet<MasterRoute> MasterRoute { get; set; }
        public virtual DbSet<MasterSection> MasterSection { get; set; }
        public virtual DbSet<MasterShift> MasterShift { get; set; }
        public virtual DbSet<MasterShiftCalendar> MasterShiftCalendar { get; set; }
        public virtual DbSet<MasterSkill> MasterSkill { get; set; }
        public virtual DbSet<MasterSkillGroup> MasterSkillGroup { get; set; }
        public virtual DbSet<MasterSkillType> MasterSkillType { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "dbo");

            modelBuilder.Entity<AttendanceC>(entity =>
            {
                entity.HasIndex(e => new { e.EmployeeId, e.WorkDate })
                    .HasName("idx1_AttendanceC");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LateMin)
                    .HasColumnName("Late_Min")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ot15)
                    .HasColumnName("OT_15")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ot3)
                    .HasColumnName("OT_3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassCode)
                    .IsRequired()
                    .HasColumnName("Pass_Code")
                    .HasColumnType("char(1)");

                entity.Property(e => e.TimeIn)
                    .IsRequired()
                    .HasColumnName("Time_In")
                    .HasMaxLength(19)
                    .IsUnicode(false);

                entity.Property(e => e.TimeOut)
                    .HasColumnName("Time_Out")
                    .HasMaxLength(19)
                    .IsUnicode(false);

                entity.Property(e => e.WorkDate)
                    .IsRequired()
                    .HasColumnName("Work_Date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkDay)
                    .HasColumnName("Work_Day")
                    .HasColumnType("decimal(2, 1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkShift)
                    .IsRequired()
                    .HasColumnName("Work_Shift")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.GlobalId)
                    .HasName("UQ__Employee__A50E8993D0F46EBD")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AvailableFlag).HasDefaultValueSql("('1')");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CardId)
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

                entity.Property(e => e.Hand)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.HireType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

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

                entity.Property(e => e.TitleThai)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<EmployeeAccount>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.AccountId });

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.EmployeeAccount)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_EmployeeUser_MasterUser_UserID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAccount)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeUser_Employee_EmployeeID");
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

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLocation)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EmployeeLocation)
                    .HasForeignKey(d => d.LocationId);
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

                entity.Property(e => e.JobFunctionId).HasColumnName("JobFunctionID");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.BusStation)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.BusStationId);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeeState)
                    .HasForeignKey<EmployeeState>(d => d.EmployeeId);

                entity.HasOne(d => d.JobFunction)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.JobFunctionId);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.LevelId);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.PositionId);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeState)
                    .HasForeignKey(d => d.ShiftId);
            });

            modelBuilder.Entity<EmployeSkills>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.SkillId });

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeSkills)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeSkills_Employee_EmployeeID");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.EmployeSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_EmployeeSkills_MasterSkill_SkillID");
            });

            modelBuilder.Entity<MasterAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__MasterAc__C9F28456EC943ACC")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MasterAccountAuthority>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.AuthorityId });

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AuthorityId).HasColumnName("AuthorityID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MasterAccountAuthority)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.MasterAccountAuthority)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_MasterUserAuthority_MasterAuthority_AuthorityID");
            });

            modelBuilder.Entity<MasterAuthority>(entity =>
            {
                entity.HasKey(e => e.AuthorityId);

                entity.Property(e => e.AuthorityId).HasColumnName("AuthorityID");

                entity.Property(e => e.AuthorityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterBusStation>(entity =>
            {
                entity.HasKey(e => e.BusStationId);

                entity.Property(e => e.BusStationId).HasColumnName("BusStationID");

                entity.Property(e => e.BusStationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BusStationName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.MasterBusStation)
                    .HasForeignKey(d => d.RouteId);
            });

            modelBuilder.Entity<MasterDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
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
                    .HasName("UQ_MasterEducationDegree_DegreeName")
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

                entity.Property(e => e.FunctionCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.MasterJobFunction)
                    .HasForeignKey(d => d.SectionId);
            });

            modelBuilder.Entity<MasterJobPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PositionName)
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

                entity.Property(e => e.LocationGroupId).HasColumnName("LocationGroupID");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LocationGroup)
                    .WithMany(p => p.MasterLocation)
                    .HasForeignKey(d => d.LocationGroupId);
            });

            modelBuilder.Entity<MasterLocationGroup>(entity =>
            {
                entity.HasKey(e => e.LocationGroupId);

                entity.Property(e => e.LocationGroupId).HasColumnName("LocationGroupID");

                entity.Property(e => e.LocationGroupName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<MasterRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId);

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RouteName)
                    .IsRequired()
                    .HasMaxLength(100);
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

            modelBuilder.Entity<MasterShiftCalendar>(entity =>
            {
                entity.HasKey(e => e.WorkDate);

                entity.Property(e => e.WorkDate).HasColumnType("date");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.WorkType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.MasterShiftCalendar)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_WorkCalendar_MasterShift_ShiftID");
            });

            modelBuilder.Entity<MasterSkill>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.SkillDescription).HasMaxLength(250);

                entity.Property(e => e.SkillGroupId).HasColumnName("SkillGroupID");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SkillTypeId).HasColumnName("SkillTypeID");

                entity.HasOne(d => d.SkillGroup)
                    .WithMany(p => p.MasterSkill)
                    .HasForeignKey(d => d.SkillGroupId);

                entity.HasOne(d => d.SkillType)
                    .WithMany(p => p.MasterSkill)
                    .HasForeignKey(d => d.SkillTypeId);
            });

            modelBuilder.Entity<MasterSkillGroup>(entity =>
            {
                entity.HasKey(e => e.SkillGroupId);

                entity.Property(e => e.SkillGroupId).HasColumnName("SkillGroupID");

                entity.Property(e => e.SkillGroupName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<MasterSkillType>(entity =>
            {
                entity.HasKey(e => e.SkillTypeId);

                entity.Property(e => e.SkillTypeId).HasColumnName("SkillTypeID");

                entity.Property(e => e.SkillTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
