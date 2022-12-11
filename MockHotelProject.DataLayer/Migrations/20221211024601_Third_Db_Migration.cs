using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockHotelProject.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ThirdDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccomodationRoomTypes");

            migrationBuilder.CreateTable(
                name: "PriceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRoomType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccomodationId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Heirarchy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceList");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.CreateTable(
                name: "AccomodationRoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccomodationId = table.Column<int>(type: "int", nullable: false),
                    Heirarchy = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RoomTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationRoomTypes", x => x.Id);
                });
        }
    }
}
