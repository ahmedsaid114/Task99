using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02_SalesDatabase.DataAccess
{
    internal class SalesContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sales> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.; initial catalog=salesdb ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).HasMaxLength(50).IsUnicode(true);
                entity.Property(p => p.Description).HasMaxLength(250).HasDefaultValue("No description");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Name).HasMaxLength(100).IsUnicode(true);
                entity.Property(c => c.Email).HasMaxLength(80).IsUnicode(false);
            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(s => s.Name).HasMaxLength(80).IsUnicode(true);
            });
            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(s => s.Date).HasDefaultValueSql("GETDATE()");
            });

        }
    }
}
