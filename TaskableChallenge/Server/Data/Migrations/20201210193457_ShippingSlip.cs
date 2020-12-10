using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskableChallenge.Server.Data.Migrations
{
    public partial class ShippingSlip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Orders",
                newName: "CreateDateUtc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDateUtc",
                table: "Orders",
                newName: "CreateDate");
        }
    }
}
