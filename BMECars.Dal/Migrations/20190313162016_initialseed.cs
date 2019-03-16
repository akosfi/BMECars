using Microsoft.EntityFrameworkCore.Migrations;

namespace BMECars.Dal.Migrations
{
    public partial class initialseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Bardi auto", "fbc5fe4c-7f97-4969-9937-23a191322bfd" },
                    { 2, "Top Cars", "fbc5fe4c-7f97-4969-9937-23a191322bfd" },
                    { 3, "EuroCar", "fbc5fe4c-7f97-4969-9937-23a191322bfd" },
                    { 4, "MyWay", "fbc5fe4c-7f97-4969-9937-23a191322bfd" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CompanyId", "Country", "IsGlobal" },
                values: new object[] { 1, "Ferihegy Airport", "Budapest", 1, "Hungary", true });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Bag", "Brand", "Category", "Climate", "CompanyId", "Door", "Image", "IsFuelFull", "PickUpLocationId", "Price", "Seat", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, 2, "Audi", 5, true, 1, 2, null, true, 1, 15000, 2, 0, 2000 },
                    { 2, 2, "Audi", 3, true, 1, 3, null, true, 1, 15000, 2, 0, 2000 },
                    { 3, 2, "Audi", 5, false, 1, 2, null, false, 1, 20000, 2, 0, 2000 },
                    { 4, 4, "BMW", 3, true, 1, 2, null, false, 1, 15000, 2, 0, 2000 },
                    { 5, 6, "BMW", 4, true, 1, 2, null, false, 1, 20000, 2, 1, 2002 },
                    { 6, 2, "BMW", 2, true, 2, 4, null, false, 1, 20000, 2, 1, 2012 },
                    { 7, 2, "BMW", 5, false, 2, 5, null, true, 1, 20000, 2, 0, 2000 },
                    { 8, 3, "Jeep", 4, true, 3, 6, null, true, 1, 15000, 2, 0, 2000 },
                    { 9, 2, "Tesla", 5, false, 3, 2, null, false, 1, 15300, 2, 1, 2000 },
                    { 10, 5, "Tesla", 2, true, 3, 9, null, true, 1, 15010, 2, 0, 2019 },
                    { 11, 4, "Toyota", 4, false, 4, 2, null, true, 1, 15900, 2, 1, 2015 },
                    { 12, 3, "Toyota", 2, true, 4, 12, null, false, 1, 150000, 2, 1, 2016 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
