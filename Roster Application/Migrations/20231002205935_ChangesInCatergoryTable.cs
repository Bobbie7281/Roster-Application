using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster_Application.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInCatergoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Clients_ClientID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Employees_EmployeeID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ClientID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_EmployeeID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ClientID",
                table: "Categories",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EmployeeID",
                table: "Categories",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Clients_ClientID",
                table: "Categories",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Employees_EmployeeID",
                table: "Categories",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
