using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySoko.Data.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ApplicationUserId",
                table: "Product",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_ApplicationUserId",
                table: "Product",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_ApplicationUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ApplicationUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Product");
        }
    }
}
