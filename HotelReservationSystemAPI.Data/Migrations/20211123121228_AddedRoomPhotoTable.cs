using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AddedRoomPhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomPhotoEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPhotoEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomPhotoLinksEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false),
                    RoomPhotoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPhotoLinksEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomPhotoLinksEntity_RoomPhotoEntity_RoomPhotoId",
                        column: x => x.RoomPhotoId,
                        principalTable: "RoomPhotoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomPhotoLinksEntity_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomPhotoLinksEntity_RoomId",
                table: "RoomPhotoLinksEntity",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPhotoLinksEntity_RoomPhotoId",
                table: "RoomPhotoLinksEntity",
                column: "RoomPhotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomPhotoLinksEntity");

            migrationBuilder.DropTable(
                name: "RoomPhotoEntity");
        }
    }
}
