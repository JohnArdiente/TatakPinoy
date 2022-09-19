using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TatakPinoy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ShipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Consignee",
                columns: table => new
                {
                    ConsigneeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNo = table.Column<string>(nullable: true),
                    ShipersName = table.Column<string>(nullable: true),
                    ShipersNo = table.Column<int>(nullable: false),
                    ConsigneesName = table.Column<string>(nullable: true),
                    ConsigneesAddr = table.Column<string>(nullable: true),
                    ConsigneesNo = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    AgentsName = table.Column<string>(nullable: true),
                    PickupDate = table.Column<DateTime>(nullable: false),
                    ShipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignee", x => x.ConsigneeId);
                    table.ForeignKey(
                        name: "FK_Consignee_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consignee_ShipmentId",
                table: "Consignee",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consignee");

            migrationBuilder.DropTable(
                name: "Shipment");
        }
    }
}
