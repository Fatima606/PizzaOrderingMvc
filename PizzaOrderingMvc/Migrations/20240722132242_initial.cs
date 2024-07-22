using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderingMvc.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base",
                columns: table => new
                {
                    baseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.baseId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaSize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingId);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizza_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "baseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzaId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Base",
                columns: new[] { "baseId", "BaseName" },
                values: new object[,]
                {
                    { new Guid("414e4852-7515-492d-a2c5-89a3416e0948"), "Thick" },
                    { new Guid("8dc0dacf-9a70-4bb0-be4c-da5fa79545a4"), "Thin" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "PizzaSize" },
                values: new object[,]
                {
                    { new Guid("58695154-e769-4669-bb6f-b8ebe2419b77"), "Large" },
                    { new Guid("5d2798ce-6346-46ac-a14c-0e6df3cebf41"), "Medium" },
                    { new Guid("c6c25d06-7396-4d1e-aab3-b2d2f602774e"), "Small" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "ToppingName" },
                values: new object[,]
                {
                    { new Guid("101c69de-9da5-481c-ac3c-adcac755a56d"), "Extra Chaeese" },
                    { new Guid("bda0b52d-c628-4238-8ac9-247b384b7f97"), "Olives" },
                    { new Guid("cc2734b1-3ce7-4c57-99de-de76eb359285"), "Pepperoni" },
                    { new Guid("cf3f6f3a-f6be-4359-a91a-f19098d60f35"), "Spinach" },
                    { new Guid("d51482b5-5a96-4052-8b6d-5fe218d88612"), "Mushroom" },
                    { new Guid("e277f521-5e51-40dc-8bd1-993cc6b5046f"), "Chicken" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PizzaId",
                table: "Order",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_BaseId",
                table: "Pizza",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Base");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
