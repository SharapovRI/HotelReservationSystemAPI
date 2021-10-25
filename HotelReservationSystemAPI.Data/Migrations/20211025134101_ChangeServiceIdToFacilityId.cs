using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class ChangeServiceIdToFacilityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalServicesId",
                table: "FacilityCosts");

            migrationBuilder.RenameColumn(
                name: "AdditionalServicesId",
                table: "FacilityCosts",
                newName: "AdditionalFacilitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_FacilityCosts_AdditionalServicesId",
                table: "FacilityCosts",
                newName: "IX_FacilityCosts_AdditionalFacilitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalFacilitiesId",
                table: "FacilityCosts",
                column: "AdditionalFacilitiesId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalFacilitiesId",
                table: "FacilityCosts");

            migrationBuilder.RenameColumn(
                name: "AdditionalFacilitiesId",
                table: "FacilityCosts",
                newName: "AdditionalServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_FacilityCosts_AdditionalFacilitiesId",
                table: "FacilityCosts",
                newName: "IX_FacilityCosts_AdditionalServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityCosts_AdditionalFacilities_AdditionalServicesId",
                table: "FacilityCosts",
                column: "AdditionalServicesId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
