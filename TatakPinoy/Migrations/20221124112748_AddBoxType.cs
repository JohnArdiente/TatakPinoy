using Microsoft.EntityFrameworkCore.Migrations;

namespace TatakPinoy.Migrations
{
    public partial class AddBoxType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoxType",
                table: "Consignee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxType",
                table: "Consignee");
        }
    }
}
