using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalServicesInOrders_AdditionalServices_AdditionServi~",
                table: "AdditionalServicesInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalServicesInOrders_Orders_OrderId",
                table: "AdditionalServicesInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_CostOfRoomsfRooms_Hotel_HotelId",
                table: "CostOfRoomsfRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_CostOfRoomsfRooms_TypesOfRooms_TypeId",
                table: "CostOfRoomsfRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_CostsOfServices_AdditionalServices_AdditionalServicesId",
                table: "CostsOfServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CostsOfServices_Hotel_HotelId",
                table: "CostsOfServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_TypesOfRooms_TypeId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypesOfRooms",
                table: "TypesOfRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostsOfServices",
                table: "CostsOfServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostOfRoomsfRooms",
                table: "CostOfRoomsfRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalServicesInOrders",
                table: "AdditionalServicesInOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalServices",
                table: "AdditionalFacilities");

            migrationBuilder.RenameTable(
                name: "TypesOfRooms",
                newName: "RoomTypes");

            migrationBuilder.RenameTable(
                name: "CostsOfServices",
                newName: "FacilityCosts");

            migrationBuilder.RenameTable(
                name: "CostOfRoomsfRooms",
                newName: "RoomsCosts");

            migrationBuilder.RenameTable(
                name: "AdditionalServicesInOrders",
                newName: "AdditionalFacilitiesInOrders");

            migrationBuilder.RenameTable(
                name: "AdditionalFacilities",
                newName: "AdditionalFacilities");

            migrationBuilder.RenameIndex(
                name: "IX_CostsOfServices_HotelId",
                table: "FacilityCosts",
                newName: "IX_ServiceCosts_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_CostsOfServices_AdditionalServicesId",
                table: "FacilityCosts",
                newName: "IX_ServiceCosts_AdditionalServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_CostOfRoomsfRooms_TypeId",
                table: "RoomsCosts",
                newName: "IX_RoomsCosts_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CostOfRoomsfRooms_HotelId",
                table: "RoomsCosts",
                newName: "IX_RoomsCosts_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalServicesInOrders_OrderId",
                table: "AdditionalFacilitiesInOrders",
                newName: "IX_AdditionalFacilitiesInOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalServicesInOrders_AdditionServiceId",
                table: "AdditionalFacilitiesInOrders",
                newName: "IX_AdditionalFacilitiesInOrders_AdditionServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCosts",
                table: "FacilityCosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsCosts",
                table: "RoomsCosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalFacilitiesInOrders",
                table: "AdditionalFacilitiesInOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalFacilities",
                table: "AdditionalFacilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFacilitiesInOrders_AdditionalFacilities_AdditionS~",
                table: "AdditionalFacilitiesInOrders",
                column: "AdditionFacilityId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFacilitiesInOrders_Orders_OrderId",
                table: "AdditionalFacilitiesInOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_TypeId",
                table: "Rooms",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsCosts_Hotel_HotelId",
                table: "RoomsCosts",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsCosts_RoomTypes_TypeId",
                table: "RoomsCosts",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCosts_AdditionalFacilities_AdditionalServicesId",
                table: "FacilityCosts",
                column: "AdditionalServicesId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCosts_Hotel_HotelId",
                table: "FacilityCosts",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFacilitiesInOrders_AdditionalFacilities_AdditionS~",
                table: "AdditionalFacilitiesInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFacilitiesInOrders_Orders_OrderId",
                table: "AdditionalFacilitiesInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_TypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsCosts_Hotel_HotelId",
                table: "RoomsCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsCosts_RoomTypes_TypeId",
                table: "RoomsCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCosts_AdditionalFacilities_AdditionalServicesId",
                table: "FacilityCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCosts_Hotel_HotelId",
                table: "FacilityCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCosts",
                table: "FacilityCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsCosts",
                table: "RoomsCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalFacilitiesInOrders",
                table: "AdditionalFacilitiesInOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalFacilities",
                table: "AdditionalFacilities");

            migrationBuilder.RenameTable(
                name: "FacilityCosts",
                newName: "CostsOfServices");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                newName: "TypesOfRooms");

            migrationBuilder.RenameTable(
                name: "RoomsCosts",
                newName: "CostOfRoomsfRooms");

            migrationBuilder.RenameTable(
                name: "AdditionalFacilitiesInOrders",
                newName: "AdditionalServicesInOrders");

            migrationBuilder.RenameTable(
                name: "AdditionalFacilities",
                newName: "AdditionalFacilities");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCosts_HotelId",
                table: "CostsOfServices",
                newName: "IX_CostsOfServices_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCosts_AdditionalServicesId",
                table: "CostsOfServices",
                newName: "IX_CostsOfServices_AdditionalServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsCosts_TypeId",
                table: "CostOfRoomsfRooms",
                newName: "IX_CostOfRoomsfRooms_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsCosts_HotelId",
                table: "CostOfRoomsfRooms",
                newName: "IX_CostOfRoomsfRooms_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalFacilitiesInOrders_OrderId",
                table: "AdditionalServicesInOrders",
                newName: "IX_AdditionalServicesInOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalFacilitiesInOrders_AdditionServiceId",
                table: "AdditionalServicesInOrders",
                newName: "IX_AdditionalServicesInOrders_AdditionServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostsOfServices",
                table: "CostsOfServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypesOfRooms",
                table: "TypesOfRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostOfRoomsfRooms",
                table: "CostOfRoomsfRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalServicesInOrders",
                table: "AdditionalServicesInOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalServices",
                table: "AdditionalFacilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalServicesInOrders_AdditionalServices_AdditionServi~",
                table: "AdditionalServicesInOrders",
                column: "AdditionFacilityId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalServicesInOrders_Orders_OrderId",
                table: "AdditionalServicesInOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostOfRoomsfRooms_Hotel_HotelId",
                table: "CostOfRoomsfRooms",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostOfRoomsfRooms_TypesOfRooms_TypeId",
                table: "CostOfRoomsfRooms",
                column: "TypeId",
                principalTable: "TypesOfRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostsOfServices_AdditionalServices_AdditionalServicesId",
                table: "CostsOfServices",
                column: "AdditionalServicesId",
                principalTable: "AdditionalFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostsOfServices_Hotel_HotelId",
                table: "CostsOfServices",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_TypesOfRooms_TypeId",
                table: "Rooms",
                column: "TypeId",
                principalTable: "TypesOfRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
