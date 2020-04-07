using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ColdSchedulesData.Models
{
    public partial class ScheduleManagementContext : DbContext
    {
        public ScheduleManagementContext()
        {
        }

        public ScheduleManagementContext(DbContextOptions<ScheduleManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArrangedSchedule> ArrangedSchedule { get; set; }
        public virtual DbSet<EmpScheduleRegistration> EmpScheduleRegistration { get; set; }
        public virtual DbSet<EmpSpecialty> EmpSpecialty { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ScheduleTemplate> ScheduleTemplate { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=schedulemanagement.c9nigxriip7d.us-east-2.rds.amazonaws.com,1433;Database=ScheduleManagement;User ID=admin;Password=Hoangpro123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArrangedSchedule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ArrangedSchedule)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_ArrangedSchedule_Employees");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.ArrangedSchedule)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_ArrangedSchedule_Specialty");
            });

            modelBuilder.Entity<EmpScheduleRegistration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpScheduleRegistration)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_EmpSchedule_Employees");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.EmpScheduleRegistration)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_EmpScheduleRegistration_Specialty");
            });

            modelBuilder.Entity<EmpSpecialty>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpSpecialty)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_EmpSpecialty_Employees");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.EmpSpecialty)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_EmpSpecialty_Specialty");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_Accounts");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Accounts_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScheduleTemplate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.ScheduleTemplate)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_ScheduleTemplate_Specialty");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
