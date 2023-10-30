using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIdAsForeignkeyInTheClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CategoryID",
                table: "Clients",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Categories_CategoryID",
                table: "Clients",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Categories_CategoryID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CategoryID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
