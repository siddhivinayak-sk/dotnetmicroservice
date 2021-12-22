using System;
using Microsoft.EntityFrameworkCore;
using MyProject.Core.Models;

namespace MyProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasKey(e => e.AccId);

            modelBuilder.Entity<Customer>().HasKey(e => e.CusId);

        }
    }
}