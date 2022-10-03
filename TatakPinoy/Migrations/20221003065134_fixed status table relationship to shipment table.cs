using Microsoft.EntityFrameworkCore.Migrations;

namespace TatakPinoy.Migrations
{
    public partial class fixedstatustablerelationshiptoshipmenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shipment_StatusId",
                table: "Shipment");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentId",
                table: "Status",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_StatusId",
                table: "Shipment",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shipment_StatusId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_StatusId",
                table: "Shipment",
                column: "StatusId",
                unique: true);
        }
    }
}
