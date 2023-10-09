using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster_Application.Migrations
{
    /// <inheritdoc />
    public partial class CreateScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ScheduleModel_ScheduleID",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleModel",
                table: "ScheduleModel");

            migrationBuilder.RenameTable(
                name: "ScheduleModel",
                newName: "Schedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Schedules_ScheduleID",
                table: "Clients",
                column: "ScheduleID",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Schedules_ScheduleID",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "ScheduleModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleModel",
                table: "ScheduleModel",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ScheduleModel_ScheduleID",
                table: "Clients",
                column: "ScheduleID",
                principalTable: "ScheduleModel",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
