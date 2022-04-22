using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Demo1a.Migrations
{
    public partial class AddProductCodeConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCode", 
                table: "Products", 
                type: "CHAR(5)",
                nullable: false);

            migrationBuilder.AddUniqueConstraint(
                name: "UNQ_ProductCode",
                table: "Products",
                column: "ProductCode"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UNQ_ProductCode", 
                table: "Products");
        }
    }
}
