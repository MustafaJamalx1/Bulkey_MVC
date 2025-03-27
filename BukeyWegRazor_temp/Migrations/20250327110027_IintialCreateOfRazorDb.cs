using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BukeyWegRazor_temp.Migrations
{
    /// <inheritdoc />
    public partial class IintialCreateOfRazorDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    CatagoreyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.CatagoreyId);
                });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "CatagoreyId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Science" },
                    { 2, 2, "History" },
                    { 3, 1, "SciFi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catagories");
        }
    }
}
