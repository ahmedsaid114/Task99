using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.DataAccess
{
    internal class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.; initial catalog=StudentSystem ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Name).HasMaxLength(100).IsUnicode(true);
                entity.Property(s => s.PhoneNumber).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(s => s.Birthday).IsRequired(false);
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Name).HasMaxLength(80).IsUnicode(true);
                entity.Property(c => c.Description).IsUnicode(true).IsRequired(false);
            });
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(r => r.Name).HasMaxLength(50).IsUnicode(true);
                entity.Property(r => r.Url).IsUnicode(false);
            });
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(h => h.Content).IsUnicode(true);
            });
            modelBuilder.Entity<StudentCourse>()
    .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
