using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMECars.Dal.Migrations
{
    public partial class AddColumnAccepedToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Reservations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CarId", "DropDownLocationId", "PickUpLocationId", "ReservationPrice", "ReserveFrom", "ReserveTo", "UserId" },
                values: new object[] { 1, 1, 1, 1, 10000, new DateTime(2019, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "fbc5fe4c-7f97-4969-9937-23a191322bfd" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CarId", "DropDownLocationId", "PickUpLocationId", "ReservationPrice", "ReserveFrom", "ReserveTo", "UserId" },
                values: new object[] { 2, 1, 1, 1, 10000, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "fbc5fe4c-7f97-4969-9937-23a191322bfd" });
        }
    }
}
