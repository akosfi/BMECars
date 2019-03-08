using Microsoft.EntityFrameworkCore.Migrations;

namespace BMECars.Dal.Migrations
{
    public partial class initialseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 1, "Bardi auto", "26ed8a02-70ff-497c-9c68-ee7913225c7e" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CompanyId", "Country", "IsGlobal" },
                values: new object[] { 1, "asdas street.", "Budapest", 1, "Hungary", true });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Bag", "Brand", "Category", "Climate", "CompanyId", "Door", "Image", "IsFuelFull", "PickUpLocationId", "Price", "Seat", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, 2, "Audi", 5, true, 1, 2, null, true, 1, 15000, 2, 0, 2000 },
                    { 2, 2, "BMW", 5, true, 1, 2, null, true, 1, 15000, 2, 0, 2000 },
                    { 3, 2, "Audi", 5, true, 1, 2, null, true, 1, 15000, 2, 0, 2000 },
                    { 4, 2, "Toyota", 3, true, 1, 2, null, true, 1, 15000, 2, 0, 2000 },
                    { 5, 2, "Tesla", 5, true, 1, 2, null, true, 1, 15000, 2, 0, 2000 }
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
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
