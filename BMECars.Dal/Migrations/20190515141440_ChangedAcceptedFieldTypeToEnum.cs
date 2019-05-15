using Microsoft.EntityFrameworkCore.Migrations;

namespace BMECars.Dal.Migrations
{
    public partial class ChangedAcceptedFieldTypeToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Accepted",
                table: "Reservations",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Accepted",
                table: "Reservations",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
