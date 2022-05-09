using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SampleWebApiWithDatabase.Models;

#nullable disable

namespace SampleWebApiWithDatabase.Data
{
    public partial class db : DbContext
    {
        public db()
        {
        }

        public db(DbContextOptions<db> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=BMMBQG3;Database=EmployeeDB;User Id=sa;Password=sqlserver");
//            }
//        }

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

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.SkillId);
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
