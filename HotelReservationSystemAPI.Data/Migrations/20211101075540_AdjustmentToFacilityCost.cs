using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AdjustmentToFacilityCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalFacilitiesId",
                table: "FacilityCosts");

            migrationBuilder.RenameColumn(
                name: "AdditionalFacilitiesId",
                table: "FacilityCosts",
                newName: "AdditionalFacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalFacilityId",
                table: "FacilityCosts",
                column: "AdditionalFacilityId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalFacilityId",
                table: "FacilityCosts");

            migrationBuilder.RenameColumn(
                name: "AdditionalFacilityId",
                table: "FacilityCosts",
                newName: "AdditionalFacilitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalFacilitiesId",
                table: "FacilityCosts",
                column: "AdditionalFacilitiesId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
