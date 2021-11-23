using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AdjustmentsToPhotoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "RoomPhotos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "HotelPhotos",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "RoomPhotos");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "HotelPhotos");
        }
    }
}
