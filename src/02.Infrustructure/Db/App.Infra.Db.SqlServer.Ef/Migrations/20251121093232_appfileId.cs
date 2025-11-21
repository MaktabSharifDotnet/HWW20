using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class appfileId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppFileId",
                table: "AppointmentRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppFileId",
                table: "AppointmentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
