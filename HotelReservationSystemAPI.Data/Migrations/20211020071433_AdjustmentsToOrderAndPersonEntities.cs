using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AdjustmentsToOrderAndPersonEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "person_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_person_id",
                table: "orders",
                column: "person_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_rooms_person_id",
                table: "orders",
                column: "person_id",
                principalTable: "rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_rooms_person_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_person_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "orders");
        }
    }
}
