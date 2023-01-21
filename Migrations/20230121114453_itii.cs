using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingEFCoreBulkExtensions.Migrations
{
    public partial class itii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("31649ec5-35c7-4677-8d57-bda66b69504a"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Unbranded Wooden Keyboard" },
                    { new Guid("36b77b17-7527-49d3-baea-455884d24ec7"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Tasty Plastic Chair" },
                    { new Guid("af540569-9e52-471e-bfc2-ebd1bc621c3f"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Practical Fresh Gloves" },
                    { new Guid("b8e3447e-f5e5-4277-8192-4d4018b96bd0"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Generic Cotton Keyboard" },
                    { new Guid("bdc55e1b-800b-42d6-a00a-44e33ffe849d"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Tasty Cotton Chips" },
                    { new Guid("bf9b778d-568d-4783-8af2-570c32dee6b3"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Practical Plastic Table" },
                    { new Guid("c5bbe1d5-2b58-4921-bbf4-9f73909b563c"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Refined Metal Car" },
                    { new Guid("c7dc399b-73c6-43e2-b16f-fd6e6f185fce"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Tasty Plastic Shirt" },
                    { new Guid("d11d9836-7ce7-4e81-966b-8b8ebe3b3009"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Handcrafted Granite Ball" },
                    { new Guid("f4cec862-c9f4-4dd4-8ce9-98bb115261cb"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Intelligent Steel Mouse" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
