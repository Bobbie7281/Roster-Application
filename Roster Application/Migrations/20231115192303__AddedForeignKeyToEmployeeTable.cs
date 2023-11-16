using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster_Application.Migrations
{
    /// <inheritdoc />
    public partial class _AddedForeignKeyToEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeCategory",
                table: "Employees",
                newName: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CategoryID",
                table: "Employees",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Categories_CategoryID",
                table: "Employees",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Categories_CategoryID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CategoryID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Employees",
                newName: "EmployeeCategory");
        }
    }
}
