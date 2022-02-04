using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AddedOrderGroupEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_PersonId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Orders",
                newName: "OrderGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                newName: "IX_Orders_OrderGroupId");

            migrationBuilder.CreateTable(
                name: "OrderGroupEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderGroupEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderGroupEntity_Users_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderGroupEntity_PersonId",
                table: "OrderGroupEntity",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderGroupEntity_OrderGroupId",
                table: "Orders",
                column: "OrderGroupId",
                principalTable: "OrderGroupEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderGroupEntity_OrderGroupId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderGroupEntity");

            migrationBuilder.RenameColumn(
                name: "OrderGroupId",
                table: "Orders",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderGroupId",
                table: "Orders",
                newName: "IX_Orders_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_PersonId",
                table: "Orders",
                column: "PersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
