using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DTModels.Database
{
    public partial class PlanDailyContext : DbContext
    {
        public PlanDailyContext()
        {
        }

        public PlanDailyContext(DbContextOptions<PlanDailyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<ReportItems> ReportItems { get; set; }
        public virtual DbSet<ReportPlan> ReportPlan { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserReports> UserReports { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RKVA90N;Database=PlanDaily;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plans>(entity =>
            {
                entity.HasKey(e => e.PlanId);

                entity.Property(e => e.PlanId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<ReportItems>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.Property(e => e.ReportId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.DuDinh).HasColumnName("Du_dinh");

                entity.Property(e => e.KeHoach)
                    .IsRequired()
                    .HasColumnName("Ke_hoach");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<ReportPlan>(entity =>
            {
                entity.HasKey(e => e.ReportPlaneId);

                entity.ToTable("Report_Plan");

                entity.Property(e => e.ReportPlaneId)
                    .HasColumnName("Report_Plane_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.ReportPlan)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Plane_Plans");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportPlan)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Plan_ReportItems");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserReports>(entity =>
            {
                entity.HasKey(e => e.UserReportId);

                entity.ToTable("User_Reports");

                entity.Property(e => e.UserReportId)
                    .HasColumnName("User_Report_Id")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.UserReports)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Reports_ReportItems");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Reports_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });
        }
    }
}
