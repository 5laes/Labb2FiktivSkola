using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb2FiktivSkola.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectionTbl> ConnectionTbls { get; set; } = null!;
        public virtual DbSet<CourseTbl> CourseTbls { get; set; } = null!;
        public virtual DbSet<EmployeeTbl> EmployeeTbls { get; set; } = null!;
        public virtual DbSet<GradeSetByTbl> GradeSetByTbls { get; set; } = null!;
        public virtual DbSet<GradeTbl> GradeTbls { get; set; } = null!;
        public virtual DbSet<PersonTbl> PersonTbls { get; set; } = null!;
        public virtual DbSet<StudentTbl> StudentTbls { get; set; } = null!;
        public virtual DbSet<TimeOfGradeTbl> TimeOfGradeTbls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = CLAES;Initial Catalog=FiktivSkolaLabb2;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectionTbl>(entity =>
            {
                entity.ToTable("ConnectionTBL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(50)
                    .HasColumnName("CourseID");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.GradeId)
                    .HasMaxLength(50)
                    .HasColumnName("GradeID");

                entity.Property(e => e.GradeSetById)
                    .HasMaxLength(50)
                    .HasColumnName("GradeSetByID");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(50)
                    .HasColumnName("PersonID");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .HasColumnName("StudentID");

                entity.Property(e => e.TimeOfGradeId)
                    .HasMaxLength(50)
                    .HasColumnName("TimeOfGradeID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.ConnectionTbls)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_ConnectionTBL_CourseTBL");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ConnectionTbls)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ConnectionTBL_EmployeeTBL");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.ConnectionTbls)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_ConnectionTBL_GradeTBL");

                entity.HasOne(d => d.GradeSetBy)
                    .WithMany(p => p.ConnectionTbls)
                    .HasForeignKey(d => d.GradeSetById)
                    .HasConstraintName("FK_ConnectionTBL_GradeSetByTBL");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ConnectionTbls)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectionTBL_PersonTBL");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ConnectionTbls)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_ConnectionTBL_StudentTBL");

                entity.HasOne(d => d.TimeOfGrade)
                    .WithMany(p => p.ConnectionTbls)
                    .HasForeignKey(d => d.TimeOfGradeId)
                    .HasConstraintName("FK_ConnectionTBL_TimeOfGradeTBL");
            });

            modelBuilder.Entity<CourseTbl>(entity =>
            {
                entity.ToTable("CourseTBL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Course).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeTbl>(entity =>
            {
                entity.ToTable("EmployeeTBL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Proffession).HasMaxLength(50);
            });

            modelBuilder.Entity<GradeSetByTbl>(entity =>
            {
                entity.ToTable("GradeSetByTBL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.GradeSetBy).HasMaxLength(50);
            });

            modelBuilder.Entity<GradeTbl>(entity =>
            {
                entity.ToTable("GradeTBL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Grade).HasMaxLength(50);
            });

            modelBuilder.Entity<PersonTbl>(entity =>
            {
                entity.ToTable("PersonTBL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.PersonNumber).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentTbl>(entity =>
            {
                entity.ToTable("StudentTBL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.ClassYear).HasMaxLength(50);
            });

            modelBuilder.Entity<TimeOfGradeTbl>(entity =>
            {
                entity.ToTable("TimeOfGradeTBL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.TimeOfGrade).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
