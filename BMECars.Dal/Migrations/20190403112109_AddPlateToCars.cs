using Microsoft.EntityFrameworkCore.Migrations;

namespace BMECars.Dal.Migrations
{
    public partial class AddPlateToCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Cars");
        }
    }
}
