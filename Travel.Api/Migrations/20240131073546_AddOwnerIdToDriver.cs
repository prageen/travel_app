using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Api.Migrations
{
    public partial class AddOwnerIdToDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Driver_OwnerId",
                table: "Driver",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Users_OwnerId",
                table: "Driver",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Users_OwnerId",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Driver_OwnerId",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Driver");
        }
    }
}
