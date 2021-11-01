using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationSystemAPI.Data.Migrations
{
    public partial class AdjustmentToModelNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_additional_services_in_orders_additional_services_addition_~",
                table: "additional_services_in_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_additional_services_in_orders_orders_order_id",
                table: "additional_services_in_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_cost_of_rooms_hotels_hotel_id",
                table: "cost_of_rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_cost_of_rooms_types_of_rooms_type_id",
                table: "cost_of_rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_costs_of_services_additional_services_additional_services_id",
                table: "costs_of_services");

            migrationBuilder.DropForeignKey(
                name: "FK_costs_of_services_hotels_hotel_id",
                table: "costs_of_services");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_rooms_person_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_rooms_room_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_roles_role_id",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_hotels_hotel_id",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_types_of_rooms_type_id",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_types_of_rooms",
                table: "types_of_rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotels",
                table: "hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_costs_of_services",
                table: "costs_of_services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cost_of_rooms",
                table: "cost_of_rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_additional_services_in_orders",
                table: "additional_services_in_orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_additional_services",
                table: "additional_services");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "persons",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "types_of_rooms",
                newName: "TypesOfRooms");

            migrationBuilder.RenameTable(
                name: "hotels",
                newName: "Hotel");

            migrationBuilder.RenameTable(
                name: "costs_of_services",
                newName: "CostsOfServices");

            migrationBuilder.RenameTable(
                name: "cost_of_rooms",
                newName: "CostOfRoomsfRooms");

            migrationBuilder.RenameTable(
                name: "additional_services_in_orders",
                newName: "AdditionalServicesInOrders");

            migrationBuilder.RenameTable(
                name: "additional_services",
                newName: "AdditionalFacilities");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "Rooms",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "hotel_id",
                table: "Rooms",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_type_id",
                table: "Rooms",
                newName: "IX_Rooms_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_hotel_id",
                table: "Rooms",
                newName: "IX_Rooms_HotelId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Persons",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Persons",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "Persons",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_persons_role_id",
                table: "Persons",
                newName: "IX_Persons_RoleId");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "Orders",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "room_id",
                table: "Orders",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Orders",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "check_out_time",
                table: "Orders",
                newName: "CheckOutTime");

            migrationBuilder.RenameColumn(
                name: "check_in_time",
                table: "Orders",
                newName: "CheckInTime");

            migrationBuilder.RenameIndex(
                name: "IX_orders_room_id",
                table: "Orders",
                newName: "IX_Orders_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_person_id",
                table: "Orders",
                newName: "IX_Orders_PersonId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TypesOfRooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TypesOfRooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "amount_of_seats",
                table: "TypesOfRooms",
                newName: "AmountOfSeats");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Hotel",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Hotel",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Hotel",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Hotel",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Hotel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "CostsOfServices",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CostsOfServices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "hotel_id",
                table: "CostsOfServices",
                newName: "HotelId");

            migrationBuilder.RenameColumn(
                name: "additional_services_id",
                table: "CostsOfServices",
                newName: "AdditionalServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_costs_of_services_hotel_id",
                table: "CostsOfServices",
                newName: "IX_CostsOfServices_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_costs_of_services_additional_services_id",
                table: "CostsOfServices",
                newName: "IX_CostsOfServices_AdditionalServicesId");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "CostOfRoomsfRooms",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CostOfRoomsfRooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "CostOfRoomsfRooms",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "hotel_id",
                table: "CostOfRoomsfRooms",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_cost_of_rooms_type_id",
                table: "CostOfRoomsfRooms",
                newName: "IX_CostOfRoomsfRooms_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_cost_of_rooms_hotel_id",
                table: "CostOfRoomsfRooms",
                newName: "IX_CostOfRoomsfRooms_HotelId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AdditionalServicesInOrders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "AdditionalServicesInOrders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "addition_service_id",
                table: "AdditionalServicesInOrders",
                newName: "AdditionFacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_additional_services_in_orders_order_id",
                table: "AdditionalServicesInOrders",
                newName: "IX_AdditionalServicesInOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_additional_services_in_orders_addition_service_id",
                table: "AdditionalServicesInOrders",
                newName: "IX_AdditionalServicesInOrders_AdditionServiceId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AdditionalFacilities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AdditionalFacilities",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypesOfRooms",
                table: "TypesOfRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostsOfServices",
                table: "CostsOfServices",
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
                name: "FK_Orders_Persons_PersonId",
                table: "Orders",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Rooms_RoomId",
                table: "Orders",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Roles_RoleId",
                table: "Persons",
                column: "RoleId",
                principalTable: "Roles",
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
                name: "FK_Rooms_TypesOfRooms_TypeId",
                table: "Rooms",
                column: "TypeId",
                principalTable: "TypesOfRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Orders_Persons_PersonId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Rooms_RoomId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Roles_RoleId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotel_HotelId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_TypesOfRooms_TypeId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypesOfRooms",
                table: "TypesOfRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

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
                name: "Rooms",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "persons");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "TypesOfRooms",
                newName: "types_of_rooms");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "hotels");

            migrationBuilder.RenameTable(
                name: "CostsOfServices",
                newName: "costs_of_services");

            migrationBuilder.RenameTable(
                name: "CostOfRoomsfRooms",
                newName: "cost_of_rooms");

            migrationBuilder.RenameTable(
                name: "AdditionalServicesInOrders",
                newName: "additional_services_in_orders");

            migrationBuilder.RenameTable(
                name: "AdditionalFacilities",
                newName: "additional_services");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rooms",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "rooms",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "rooms",
                newName: "hotel_id");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_TypeId",
                table: "rooms",
                newName: "IX_rooms_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelId",
                table: "rooms",
                newName: "IX_rooms_hotel_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "persons",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "persons",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "persons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "persons",
                newName: "role_id");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_RoleId",
                table: "persons",
                newName: "IX_persons_role_id");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "orders",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "orders",
                newName: "room_id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "orders",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "CheckOutTime",
                table: "orders",
                newName: "check_out_time");

            migrationBuilder.RenameColumn(
                name: "CheckInTime",
                table: "orders",
                newName: "check_in_time");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RoomId",
                table: "orders",
                newName: "IX_orders_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PersonId",
                table: "orders",
                newName: "IX_orders_person_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "types_of_rooms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "types_of_rooms",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "AmountOfSeats",
                table: "types_of_rooms",
                newName: "amount_of_seats");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "hotels",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "hotels",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "hotels",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "hotels",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "hotels",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "costs_of_services",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "costs_of_services",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "costs_of_services",
                newName: "hotel_id");

            migrationBuilder.RenameColumn(
                name: "AdditionalServicesId",
                table: "costs_of_services",
                newName: "additional_services_id");

            migrationBuilder.RenameIndex(
                name: "IX_CostsOfServices_HotelId",
                table: "costs_of_services",
                newName: "IX_costs_of_services_hotel_id");

            migrationBuilder.RenameIndex(
                name: "IX_CostsOfServices_AdditionalServicesId",
                table: "costs_of_services",
                newName: "IX_costs_of_services_additional_services_id");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "cost_of_rooms",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cost_of_rooms",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "cost_of_rooms",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "cost_of_rooms",
                newName: "hotel_id");

            migrationBuilder.RenameIndex(
                name: "IX_CostOfRoomsfRooms_TypeId",
                table: "cost_of_rooms",
                newName: "IX_cost_of_rooms_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_CostOfRoomsfRooms_HotelId",
                table: "cost_of_rooms",
                newName: "IX_cost_of_rooms_hotel_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "additional_services_in_orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "additional_services_in_orders",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "AdditionFacilityId",
                table: "additional_services_in_orders",
                newName: "addition_service_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalServicesInOrders_OrderId",
                table: "additional_services_in_orders",
                newName: "IX_additional_services_in_orders_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalServicesInOrders_AdditionServiceId",
                table: "additional_services_in_orders",
                newName: "IX_additional_services_in_orders_addition_service_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "additional_services",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "additional_services",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rooms",
                table: "rooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                table: "persons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_types_of_rooms",
                table: "types_of_rooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotels",
                table: "hotels",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_costs_of_services",
                table: "costs_of_services",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cost_of_rooms",
                table: "cost_of_rooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_additional_services_in_orders",
                table: "additional_services_in_orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_additional_services",
                table: "additional_services",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_additional_services_in_orders_additional_services_addition_~",
                table: "additional_services_in_orders",
                column: "addition_service_id",
                principalTable: "additional_services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_additional_services_in_orders_orders_order_id",
                table: "additional_services_in_orders",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cost_of_rooms_hotels_hotel_id",
                table: "cost_of_rooms",
                column: "hotel_id",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cost_of_rooms_types_of_rooms_type_id",
                table: "cost_of_rooms",
                column: "type_id",
                principalTable: "types_of_rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_costs_of_services_additional_services_additional_services_id",
                table: "costs_of_services",
                column: "additional_services_id",
                principalTable: "additional_services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_costs_of_services_hotels_hotel_id",
                table: "costs_of_services",
                column: "hotel_id",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_rooms_person_id",
                table: "orders",
                column: "person_id",
                principalTable: "rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_rooms_room_id",
                table: "orders",
                column: "room_id",
                principalTable: "rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_roles_role_id",
                table: "persons",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_hotels_hotel_id",
                table: "rooms",
                column: "hotel_id",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_types_of_rooms_type_id",
                table: "rooms",
                column: "type_id",
                principalTable: "types_of_rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
