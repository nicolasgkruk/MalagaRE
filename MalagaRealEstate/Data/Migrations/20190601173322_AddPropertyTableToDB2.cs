using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MalagaRealEstate.Data.Migrations
{
    public partial class AddPropertyTableToDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Rooms = table.Column<int>(nullable: false),
                    Bathrooms = table.Column<int>(nullable: false),
                    FloorNumber = table.Column<int>(nullable: false),
                    SquareMeters = table.Column<int>(nullable: false),
                    OwnerPrice = table.Column<int>(nullable: false),
                    Garaje = table.Column<bool>(nullable: false),
                    AirConditioning = table.Column<bool>(nullable: false),
                    Elevator = table.Column<bool>(nullable: false),
                    Exterior = table.Column<bool>(nullable: false),
                    Garden = table.Column<bool>(nullable: false),
                    SwimmingPool = table.Column<bool>(nullable: false),
                    Terrace = table.Column<bool>(nullable: false),
                    StorageRoom = table.Column<bool>(nullable: false),
                    PostedDay = table.Column<DateTime>(nullable: false),
                    PropType = table.Column<int>(nullable: false),
                    PropState = table.Column<int>(nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,16)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,15)", nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
