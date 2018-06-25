using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyTool.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FinishRate = table.Column<float>(nullable: false),
                    Create_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Report_Plan",
                columns: table => new
                {
                    Report_Plane_Id = table.Column<Guid>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false),
                    PlandId = table.Column<Guid>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report_Plan", x => x.Report_Plane_Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportItems",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Du_dinh = table.Column<string>(nullable: true),
                    IsFinish = table.Column<bool>(nullable: false),
                    Ke_hoach = table.Column<string>(nullable: true),
                    Issue = table.Column<string>(nullable: true),
                    Created_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportItems", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User_Reports",
                columns: table => new
                {
                    User_Report_Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Reports", x => x.User_Report_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Create_At = table.Column<DateTime>(nullable: false),
                    ReportReceiver = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Report_Plan");

            migrationBuilder.DropTable(
                name: "ReportItems");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User_Reports");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
