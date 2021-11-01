using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AdjustmentToHotelsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityCosts_Hotel_HotelId",
                table: "FacilityCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Cities_CityId",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Countries_CountryId",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotel_HotelId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsCosts_Hotel_HotelId",
                table: "RoomsCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "Hotels");

            migrationBuilder.RenameIndex(
                name: "IX_Hotel_CountryId",
                table: "Hotels",
                newName: "IX_Hotels_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotel_CityId",
                table: "Hotels",
                newName: "IX_Hotels_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityCosts_Hotels_HotelId",
                table: "FacilityCosts",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Cities_CityId",
                table: "Hotels",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsCosts_Hotels_HotelId",
                table: "RoomsCosts",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityCosts_Hotels_HotelId",
                table: "FacilityCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Cities_CityId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsCosts_Hotels_HotelId",
                table: "RoomsCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "Hotel");

            migrationBuilder.RenameIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotel",
                newName: "IX_Hotel_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotels_CityId",
                table: "Hotel",
                newName: "IX_Hotel_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityCosts_Hotel_HotelId",
                table: "FacilityCosts",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Cities_CityId",
                table: "Hotel",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Countries_CountryId",
                table: "Hotel",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotel_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsCosts_Hotel_HotelId",
                table: "RoomsCosts",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
