using Microsoft.EntityFrameworkCore.Migrations;

namespace TatakPinoy.Migrations
{
    public partial class fixedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsigneeStatus_Consignee_ConsigneeId",
                table: "ConsigneeStatus");

            migrationBuilder.DropIndex(
                name: "IX_ConsigneeStatus_ConsigneeId",
                table: "ConsigneeStatus");

            migrationBuilder.DropColumn(
                name: "ConsigneeId",
                table: "ConsigneeStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Consignee_ConsigneeStatusId",
                table: "Consignee",
                column: "ConsigneeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consignee_ConsigneeStatus_ConsigneeStatusId",
                table: "Consignee",
                column: "ConsigneeStatusId",
                principalTable: "ConsigneeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consignee_ConsigneeStatus_ConsigneeStatusId",
                table: "Consignee");

            migrationBuilder.DropIndex(
                name: "IX_Consignee_ConsigneeStatusId",
                table: "Consignee");

            migrationBuilder.AddColumn<int>(
                name: "ConsigneeId",
                table: "ConsigneeStatus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsigneeStatus_ConsigneeId",
                table: "ConsigneeStatus",
                column: "ConsigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsigneeStatus_Consignee_ConsigneeId",
                table: "ConsigneeStatus",
                column: "ConsigneeId",
                principalTable: "Consignee",
                principalColumn: "ConsigneeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
