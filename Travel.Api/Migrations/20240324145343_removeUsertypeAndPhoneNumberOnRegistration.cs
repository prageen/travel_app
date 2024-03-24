using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Api.Migrations
{
    public partial class removeUsertypeAndPhoneNumberOnRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passowrd",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Registrations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Passowrd",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
