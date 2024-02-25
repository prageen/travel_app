using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Api.Migrations
{
    public partial class AddTablePlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "Plans",
        columns: table => new
        {
            PlanId = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            PlanName = table.Column<string>(nullable: false),
            PlanDesription = table.Column<string>(nullable: true),
            Days = table.Column<int>(nullable: false),
            Status = table.Column<int>(nullable: false, defaultValue: 1) // Set default value here
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Plans", x => x.PlanId);
        });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "Plans");
        }
    }
}
