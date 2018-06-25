using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyTool.Models
{
    public class CodeDbContext:DbContext
    {
        public CodeDbContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ReportItems> ReportItems { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Report_Plan> Report_Plan { get; set; }
        public DbSet<User_Reports> User_Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
