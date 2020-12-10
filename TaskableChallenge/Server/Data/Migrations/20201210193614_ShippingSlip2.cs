using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskableChallenge.Server.Data.Migrations
{
    public partial class ShippingSlip2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingSlip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreateDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingSlip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingSlip_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingSlip_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingSlipLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingSlipId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingSlipLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingSlipLine_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingSlipLine_ShippingSlip_ShippingSlipId",
                        column: x => x.ShippingSlipId,
                        principalTable: "ShippingSlip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingSlip_CustomerId",
                table: "ShippingSlip",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingSlip_OrderId",
                table: "ShippingSlip",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingSlipLine_ProductId",
                table: "ShippingSlipLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingSlipLine_ShippingSlipId",
                table: "ShippingSlipLine",
                column: "ShippingSlipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingSlipLine");

            migrationBuilder.DropTable(
                name: "ShippingSlip");
        }
    }
}
