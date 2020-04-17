using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSolution.Infrastructure.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Base64Photo",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfJobs",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Photo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NumberOfJobs",
                table: "Students");
        }
    }
}
