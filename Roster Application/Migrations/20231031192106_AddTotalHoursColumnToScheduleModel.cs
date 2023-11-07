using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalHoursColumnToScheduleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleTotalHours",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleTotalHours",
                table: "Schedules");
        }
    }
}
