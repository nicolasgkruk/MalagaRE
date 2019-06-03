using Microsoft.EntityFrameworkCore.Migrations;

namespace MalagaRealEstate.Data.Migrations
{
    public partial class AddedAddressToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Properties");
        }
    }
}
