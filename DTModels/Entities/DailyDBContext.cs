using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTModels.Entities
{
    public class DailyDBContext : DbContext
    {
        public DailyDBContext()
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Report_Items> Report_Items { get; set; }
        public DbSet<User_Reports> User_Reports { get; set; }

        public DailyDBContext(DbContextOptions<DailyDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.;Database=DailyToolDB;Trusted_Connection=True;ConnectRetryCount=0;User Id=sa;Password=123456;");
        }
    }
}
