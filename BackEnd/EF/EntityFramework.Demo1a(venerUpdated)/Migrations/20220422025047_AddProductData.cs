using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Demo1a.Migrations
{
    public partial class AddProductData : Migration
    {
        private static object[,] GetProductData()
        {
            return new object[,]
                {
                    { "Product1", 1500M, "P0001" },
                    { "Product1", 1500M, "P0002" }
                };
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Price", "ProductCode" },
                values: GetProductData());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
 
            migrationBuilder.DeleteData("Products", "ProductCode", "P0001");
            migrationBuilder.DeleteData("Products", "ProductCode", "P0002");

        }
    }
}
