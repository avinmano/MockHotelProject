using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockHotelProject.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SecondDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationRoomTypes_Accomodations_AccomodationId",
                table: "AccomodationRoomTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_AccomodationRoomTypes_RoomTypes_RoomTypeId",
                table: "AccomodationRoomTypes");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccomodationRoomTypes_AccomodationId",
                table: "AccomodationRoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccomodationRoomTypes_RoomTypeId",
                table: "AccomodationRoomTypes");

            migrationBuilder.DropColumn(
                name: "Hierarchy",
                table: "AccomodationRoomTypes");

            migrationBuilder.DropColumn(
                name: "MaxAvailability",
                table: "AccomodationRoomTypes");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "AccomodationRoomTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hierarchy",
                table: "AccomodationRoomTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAvailability",
                table: "AccomodationRoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "AccomodationRoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccomodationRoomTypeId = table.Column<int>(type: "int", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAccomodationRoomType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_AccomodationRoomTypes_AccomodationRoomTypeId",
                        column: x => x.AccomodationRoomTypeId,
                        principalTable: "AccomodationRoomTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationRoomTypes_AccomodationId",
                table: "AccomodationRoomTypes",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationRoomTypes_RoomTypeId",
                table: "AccomodationRoomTypes",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AccomodationRoomTypeId",
                table: "Booking",
                column: "AccomodationRoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationRoomTypes_Accomodations_AccomodationId",
                table: "AccomodationRoomTypes",
                column: "AccomodationId",
                principalTable: "Accomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccomodationRoomTypes_RoomTypes_RoomTypeId",
                table: "AccomodationRoomTypes",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
