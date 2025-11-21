using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class AppFilesnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "AppFiles");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "AppFiles",
                newName: "Path");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentRequestId",
                table: "AppFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppFiles_AppointmentRequestId",
                table: "AppFiles",
                column: "AppointmentRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_AppointmentRequests_AppointmentRequestId",
                table: "AppFiles",
                column: "AppointmentRequestId",
                principalTable: "AppointmentRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_AppointmentRequests_AppointmentRequestId",
                table: "AppFiles");

            migrationBuilder.DropIndex(
                name: "IX_AppFiles_AppointmentRequestId",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "AppointmentRequestId",
                table: "AppFiles");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "AppFiles",
                newName: "FilePath");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AppFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "AppFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "AppFiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
