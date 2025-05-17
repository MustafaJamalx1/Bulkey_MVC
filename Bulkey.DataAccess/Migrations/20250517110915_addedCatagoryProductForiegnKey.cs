using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulkey.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedCatagoryProductForiegnKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CatagoreyId",
                table: "Catagories",
                newName: "CatagoryId");

            migrationBuilder.AddColumn<int>(
                name: "CatagoryProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CatagoryProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CatagoryProductId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CatagoryProductId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CatagoryProductId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CatagoryProductId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CatagoryProductId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoryProductId",
                table: "Products",
                column: "CatagoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CatagoryProductId",
                table: "Products",
                column: "CatagoryProductId",
                principalTable: "Catagories",
                principalColumn: "CatagoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CatagoryProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatagoryProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatagoryProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "Catagories",
                newName: "CatagoreyId");
        }
    }
}
