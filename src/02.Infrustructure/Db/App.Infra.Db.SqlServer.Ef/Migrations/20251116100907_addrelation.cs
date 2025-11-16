using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class addrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "FailedRequestLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "AppointmentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FailedRequestLogs_OperatorId",
                table: "FailedRequestLogs",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRequests_OperatorId",
                table: "AppointmentRequests",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRequests_Operators_OperatorId",
                table: "AppointmentRequests",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FailedRequestLogs_Operators_OperatorId",
                table: "FailedRequestLogs",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRequests_Operators_OperatorId",
                table: "AppointmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FailedRequestLogs_Operators_OperatorId",
                table: "FailedRequestLogs");

            migrationBuilder.DropIndex(
                name: "IX_FailedRequestLogs_OperatorId",
                table: "FailedRequestLogs");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentRequests_OperatorId",
                table: "AppointmentRequests");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "FailedRequestLogs");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "AppointmentRequests");
        }
    }
}
