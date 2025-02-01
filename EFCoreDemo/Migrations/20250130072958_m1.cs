using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Grocery" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Laptop", 500m },
                    { 2, 1, "Smartphone", 300m },
                    { 3, 1, "Headphones", 50m },
                    { 4, 1, "Smartwatch", 150m },
                    { 5, 1, "Tablet", 200m },
                    { 6, 1, "Camera", 350m },
                    { 7, 1, "Drone", 400m },
                    { 8, 1, "Bluetooth Speaker", 60m },
                    { 9, 1, "Keyboard", 30m },
                    { 10, 1, "Mouse", 20m },
                    { 11, 2, "T-Shirt", 10m },
                    { 12, 2, "Jeans", 25m },
                    { 13, 2, "Jacket", 40m },
                    { 14, 2, "Shoes", 50m },
                    { 15, 2, "Sweater", 30m },
                    { 16, 2, "Hat", 15m },
                    { 17, 2, "Socks", 5m },
                    { 18, 2, "Scarf", 12m },
                    { 19, 2, "Shorts", 20m },
                    { 20, 2, "Gloves", 18m },
                    { 21, 3, "Rice", 5m },
                    { 22, 3, "Wheat Flour", 3m },
                    { 23, 3, "Sugar", 2m },
                    { 24, 3, "Salt", 1m },
                    { 25, 3, "Cooking Oil", 6m },
                    { 26, 3, "Milk", 6m },
                    { 27, 3, "Eggs", 2m },
                    { 28, 3, "Butter", 4m },
                    { 29, 3, "Cheese", 5m },
                    { 30, 3, "Potatoes", 3m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
