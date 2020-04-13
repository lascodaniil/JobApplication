using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSolution.Infrastructure.Migrations
{
    public partial class InitV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Base64Photo",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Photo",
                table: "Jobs");
        }
    }
}
