using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TatakPinoy.Migrations
{
    public partial class addedconsigneeStatusHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsigneeStatus_Consignee_ConsigneeId",
                table: "ConsigneeStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsigneeStatus",
                table: "ConsigneeStatus");

            migrationBuilder.DropColumn(
                name: "ConsigneeStatusId",
                table: "ConsigneeStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ConsigneeStatus");

            migrationBuilder.AlterColumn<int>(
                name: "ConsigneeId",
                table: "ConsigneeStatus",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ConsigneeStatus",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsigneeStatus",
                table: "ConsigneeStatus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ConsigneeStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsigneeStatusId = table.Column<int>(nullable: false),
                    ConsigneeId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsigneeStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsigneeStatusHistories_Consignee_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalTable: "Consignee",
                        principalColumn: "ConsigneeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsigneeStatusHistories_ConsigneeStatus_ConsigneeStatusId",
                        column: x => x.ConsigneeStatusId,
                        principalTable: "ConsigneeStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsigneeStatusHistories_ConsigneeId",
                table: "ConsigneeStatusHistories",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsigneeStatusHistories_ConsigneeStatusId",
                table: "ConsigneeStatusHistories",
                column: "ConsigneeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsigneeStatus_Consignee_ConsigneeId",
                table: "ConsigneeStatus",
                column: "ConsigneeId",
                principalTable: "Consignee",
                principalColumn: "ConsigneeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsigneeStatus_Consignee_ConsigneeId",
                table: "ConsigneeStatus");

            migrationBuilder.DropTable(
                name: "ConsigneeStatusHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsigneeStatus",
                table: "ConsigneeStatus");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConsigneeStatus");

            migrationBuilder.AlterColumn<int>(
                name: "ConsigneeId",
                table: "ConsigneeStatus",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsigneeStatusId",
                table: "ConsigneeStatus",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ConsigneeStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsigneeStatus",
                table: "ConsigneeStatus",
                column: "ConsigneeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsigneeStatus_Consignee_ConsigneeId",
                table: "ConsigneeStatus",
                column: "ConsigneeId",
                principalTable: "Consignee",
                principalColumn: "ConsigneeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
