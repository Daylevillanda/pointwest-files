using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestDB.Models;

#nullable disable

namespace TestDB.Data
{
    public partial class EmpContext : DbContext
    {
        public EmpContext()
        {
        }

        public EmpContext(DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<PlacementContract> PlacementContracts { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BMMBQG3;Database=WorkSchedule;User Id=sa;Password=sqlserver");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeSkills_EmployeeID");

                entity.HasIndex(e => e.SkillId, "IX_EmployeeSkills_SkillID");

                entity.Property(e => e.EmployeeSkillId).HasColumnName("EmployeeSkillID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.HourlyWage).HasColumnType("money");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.YearsOfexperience).HasColumnName("YearsOFExperience");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.SkillId);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PlacementContract>(entity =>
            {
                entity.HasIndex(e => e.LocationId, "IX_PlacementContracts_LocationID");

                entity.Property(e => e.PlacementContractId).HasColumnName("PlacementContractID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PlacementContracts)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_Schedules_EmployeeID");

                entity.HasIndex(e => e.ShiftId, "IX_Schedules_ShiftID");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.HourlyWage).HasColumnType("money");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ShiftId);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasIndex(e => e.PlacementContractId, "IX_Shifts_PlacementContractID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.PlacementContractId).HasColumnName("PlacementContractID");

                entity.HasOne(d => d.PlacementContract)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.PlacementContractId);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
