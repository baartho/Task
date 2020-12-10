using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskableChallenge.Server.Data.Migrations
{
    public partial class ShippingSlip3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingSlip_Customers_CustomerId",
                table: "ShippingSlip");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingSlip_Orders_OrderId",
                table: "ShippingSlip");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingSlipLine_ShippingSlip_ShippingSlipId",
                table: "ShippingSlipLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingSlip",
                table: "ShippingSlip");

            migrationBuilder.RenameTable(
                name: "ShippingSlip",
                newName: "ShippingSlips");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingSlip_OrderId",
                table: "ShippingSlips",
                newName: "IX_ShippingSlips_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingSlip_CustomerId",
                table: "ShippingSlips",
                newName: "IX_ShippingSlips_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingSlips",
                table: "ShippingSlips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingSlipLine_ShippingSlips_ShippingSlipId",
                table: "ShippingSlipLine",
                column: "ShippingSlipId",
                principalTable: "ShippingSlips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingSlips_Customers_CustomerId",
                table: "ShippingSlips",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingSlips_Orders_OrderId",
                table: "ShippingSlips",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingSlipLine_ShippingSlips_ShippingSlipId",
                table: "ShippingSlipLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingSlips_Customers_CustomerId",
                table: "ShippingSlips");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingSlips_Orders_OrderId",
                table: "ShippingSlips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingSlips",
                table: "ShippingSlips");

            migrationBuilder.RenameTable(
                name: "ShippingSlips",
                newName: "ShippingSlip");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingSlips_OrderId",
                table: "ShippingSlip",
                newName: "IX_ShippingSlip_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingSlips_CustomerId",
                table: "ShippingSlip",
                newName: "IX_ShippingSlip_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingSlip",
                table: "ShippingSlip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingSlip_Customers_CustomerId",
                table: "ShippingSlip",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingSlip_Orders_OrderId",
                table: "ShippingSlip",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingSlipLine_ShippingSlip_ShippingSlipId",
                table: "ShippingSlipLine",
                column: "ShippingSlipId",
                principalTable: "ShippingSlip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
