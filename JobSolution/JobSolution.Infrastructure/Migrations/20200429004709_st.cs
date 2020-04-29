using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSolution.Infrastructure.Migrations
{
    public partial class st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EnrolledDate",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrolledDate",
                table: "Jobs");
        }
    }
}
