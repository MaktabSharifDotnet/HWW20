using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Operators",
                newName: "Password");

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "Company", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Saipa", false, "پراید 131" },
                    { 2, "Saipa", false, "تیبا 2" },
                    { 3, "Saipa", false, "شاهین" },
                    { 4, "IranKhodro", false, "پژو 206" },
                    { 5, "IranKhodro", false, "پژو پارس" },
                    { 6, "IranKhodro", false, "سمند LX" },
                    { 7, "IranKhodro", false, "دنا پلاس" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Operators",
                newName: "PasswordHash");
        }
    }
}
