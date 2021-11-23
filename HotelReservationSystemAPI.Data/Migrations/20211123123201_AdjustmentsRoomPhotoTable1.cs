using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AdjustmentsRoomPhotoTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhotoLinksEntity_RoomPhotoEntity_RoomPhotoId",
                table: "RoomPhotoLinksEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhotoLinksEntity_Rooms_RoomId",
                table: "RoomPhotoLinksEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPhotoLinksEntity",
                table: "RoomPhotoLinksEntity");

            migrationBuilder.DropIndex(
                name: "IX_RoomPhotoLinksEntity_RoomPhotoId",
                table: "RoomPhotoLinksEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPhotoEntity",
                table: "RoomPhotoEntity");

            migrationBuilder.DropColumn(
                name: "RoomPhotoId",
                table: "RoomPhotoLinksEntity");

            migrationBuilder.RenameTable(
                name: "RoomPhotoLinksEntity",
                newName: "RoomPhotoLinks");

            migrationBuilder.RenameTable(
                name: "RoomPhotoEntity",
                newName: "RoomPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPhotoLinksEntity_RoomId",
                table: "RoomPhotoLinks",
                newName: "IX_RoomPhotoLinks_RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "RoomPhotos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "RoomPhotos",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPhotoLinks",
                table: "RoomPhotoLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPhotos",
                table: "RoomPhotos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPhotoLinks_PhotoId",
                table: "RoomPhotoLinks",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhotoLinks_RoomPhotos_PhotoId",
                table: "RoomPhotoLinks",
                column: "PhotoId",
                principalTable: "RoomPhotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhotoLinks_Rooms_RoomId",
                table: "RoomPhotoLinks",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhotoLinks_RoomPhotos_PhotoId",
                table: "RoomPhotoLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhotoLinks_Rooms_RoomId",
                table: "RoomPhotoLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPhotos",
                table: "RoomPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPhotoLinks",
                table: "RoomPhotoLinks");

            migrationBuilder.DropIndex(
                name: "IX_RoomPhotoLinks_PhotoId",
                table: "RoomPhotoLinks");

            migrationBuilder.RenameTable(
                name: "RoomPhotos",
                newName: "RoomPhotoEntity");

            migrationBuilder.RenameTable(
                name: "RoomPhotoLinks",
                newName: "RoomPhotoLinksEntity");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPhotoLinks_RoomId",
                table: "RoomPhotoLinksEntity",
                newName: "IX_RoomPhotoLinksEntity_RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "RoomPhotoEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "RoomPhotoEntity",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<int>(
                name: "RoomPhotoId",
                table: "RoomPhotoLinksEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPhotoEntity",
                table: "RoomPhotoEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPhotoLinksEntity",
                table: "RoomPhotoLinksEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPhotoLinksEntity_RoomPhotoId",
                table: "RoomPhotoLinksEntity",
                column: "RoomPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhotoLinksEntity_RoomPhotoEntity_RoomPhotoId",
                table: "RoomPhotoLinksEntity",
                column: "RoomPhotoId",
                principalTable: "RoomPhotoEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhotoLinksEntity_Rooms_RoomId",
                table: "RoomPhotoLinksEntity",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
