using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class ChangeServiceCostToFacilityCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityCosts");

            migrationBuilder.CreateTable(
                name: "FacilityCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    AdditionalServicesId = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityCosts_AdditionalFacilities_AdditionalServicesId",
                        column: x => x.AdditionalServicesId,
                        principalTable: "AdditionalFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityCosts_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityCosts_AdditionalServicesId",
                table: "FacilityCosts",
                column: "AdditionalServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityCosts_HotelId",
                table: "FacilityCosts",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityCosts");

            migrationBuilder.CreateTable(
                name: "FacilityCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdditionalServicesId = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCosts_AdditionalFacilities_AdditionalServicesId",
                        column: x => x.AdditionalServicesId,
                        principalTable: "AdditionalFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCosts_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCosts_AdditionalServicesId",
                table: "FacilityCosts",
                column: "AdditionalServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCosts_HotelId",
                table: "FacilityCosts",
                column: "HotelId");
        }
    }
}
