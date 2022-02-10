using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityAPI.Migrations
{
    public partial class init_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_DirectionId",
                table: "Students",
                column: "DirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Directions_DirectionId",
                table: "Students",
                column: "DirectionId",
                principalTable: "Directions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Directions_DirectionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DirectionId",
                table: "Students");
        }
    }
}
