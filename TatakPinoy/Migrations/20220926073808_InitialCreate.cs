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
                    ShipmentNo = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ShipmentId);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Consignee",
                columns: table => new
                {
                    ConsigneeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNo = table.Column<string>(nullable: true),
                    ShipersName = table.Column<string>(nullable: true),
                    ShipersNo = table.Column<string>(nullable: true),
                    ConsigneesName = table.Column<string>(nullable: true),
                    ConsigneesAddr = table.Column<string>(nullable: true),
                    ConsigneesNo = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    AgentsName = table.Column<string>(nullable: true),
                    PickupDate = table.Column<DateTime>(nullable: false),
                    ShipmentId = table.Column<int>(nullable: true),
                    ConsigneeStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignee", x => x.ConsigneeId);
                    table.ForeignKey(
                        name: "FK_Consignee_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDesc = table.Column<string>(nullable: true),
                    ShipmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_Status_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsigneeStatus",
                columns: table => new
                {
                    ConsigneeStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsigneeStatusDesc = table.Column<string>(nullable: true),
                    ConsigneeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsigneeStatus", x => x.ConsigneeStatusId);
                    table.ForeignKey(
                        name: "FK_ConsigneeStatus_Consignee_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalTable: "Consignee",
                        principalColumn: "ConsigneeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consignee_ShipmentId",
                table: "Consignee",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsigneeStatus_ConsigneeId",
                table: "ConsigneeStatus",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_ShipmentId",
                table: "Status",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsigneeStatus");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "Consignee");

            migrationBuilder.DropTable(
                name: "Shipment");
        }
    }
}
