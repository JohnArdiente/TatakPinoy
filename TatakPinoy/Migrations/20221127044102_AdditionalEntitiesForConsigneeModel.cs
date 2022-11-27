using Microsoft.EntityFrameworkCore.Migrations;

namespace TatakPinoy.Migrations
{
    public partial class AdditionalEntitiesForConsigneeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Consignee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IrregularQuantity",
                table: "Consignee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JumboQuantity",
                table: "Consignee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Others",
                table: "Consignee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegularQuantity",
                table: "Consignee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecifyOthers",
                table: "Consignee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "IrregularQuantity",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "JumboQuantity",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "RegularQuantity",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "SpecifyOthers",
                table: "Consignee");
        }
    }
}
