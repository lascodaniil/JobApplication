using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSolution.Infrastructure.Migrations
{
    public partial class _2st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ImageId",
                table: "Profiles",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Images_ImageId",
                table: "Profiles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Images_ImageId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ImageId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Profiles");
        }
    }
}
