using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class DeletedFacilityCostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityCosts");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "AdditionalFacilities",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "AdditionalFacilities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFacilities_HotelId",
                table: "AdditionalFacilities",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFacilities_Hotels_HotelId",
                table: "AdditionalFacilities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFacilities_Hotels_HotelId",
                table: "AdditionalFacilities");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFacilities_HotelId",
                table: "AdditionalFacilities");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "AdditionalFacilities");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "AdditionalFacilities");

            migrationBuilder.CreateTable(
                name: "FacilityCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdditionalFacilityId = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityCosts_AdditionalFacilities_AdditionalFacilityId",
                        column: x => x.AdditionalFacilityId,
                        principalTable: "AdditionalFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityCosts_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityCosts_AdditionalFacilityId",
                table: "FacilityCosts",
                column: "AdditionalFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityCosts_HotelId",
                table: "FacilityCosts",
                column: "HotelId");
        }
    }
}
