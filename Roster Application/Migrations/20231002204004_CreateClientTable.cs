using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster_Application.Migrations
{
    /// <inheritdoc />
    public partial class CreateClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleModel",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleMonTotHours = table.Column<int>(type: "int", nullable: false),
                    ScheduleTueTotHours = table.Column<int>(type: "int", nullable: false),
                    ScheduleWedTotHours = table.Column<int>(type: "int", nullable: false),
                    ScheduleThurTotHours = table.Column<int>(type: "int", nullable: false),
                    ScheduleFriTotHours = table.Column<int>(type: "int", nullable: false),
                    ScheduleSatTotHours = table.Column<int>(type: "int", nullable: false),
                    ScheduleSunTotHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleModel", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleID = table.Column<int>(type: "int", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_ScheduleModel_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "ScheduleModel",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ScheduleID",
                table: "Clients",
                column: "ScheduleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ScheduleModel");
        }
    }
}
