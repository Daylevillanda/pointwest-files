using Bogus;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace EntityFrameworkDemo.Migrations
{
    public partial class SeedInitialData : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var faker = new Faker("en");

            foreach (int num in Enumerable.Range(1, 100).Select(x => x * x))
            {
                migrationBuilder.InsertData(
                    table: "Products",
                    columns: new[] { "Name", "Price" },
                    values: new object[] { faker.Commerce.ProductName(), faker.Commerce.Price() }
                );
            }


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
