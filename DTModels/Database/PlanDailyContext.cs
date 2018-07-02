using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTModels.Database
{
    public class PlanDailyContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Plan_Items> Plan_Items { get; set; }
        public DbSet<User_Reports> User_Reports { get; set; }

        public PlanDailyContext(DbContextOptions<PlanDailyContext> options)
            : base(options)
        {
        }

        public PlanDailyContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PlanDaily;Trusted_Connection=True;User Id=sa;Password=123456;");
        }
    }
}
