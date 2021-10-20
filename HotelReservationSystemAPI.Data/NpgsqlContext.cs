using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Data
{
    public class NpgsqlContext : DbContext //-Project HotelReservationSystemAPI.Data
    {
        public DbSet<AdditionalServiceEntity> AdditionalServices { get; set; }
        public DbSet<AdditionalServicesInOrderEntity> AdditionalServicesInOrders { get; set; }
        public DbSet<CostOfRoomsEntity> CostOfRoomsfRooms { get; set; }
        public DbSet<CostsOfServicesEntity> CostsOfServices { get; set; }
        public DbSet<HotelEntity> Hotel { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<TypesOfRoomsEntity> TypesOfRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HotelReservationSystemAPI_DB;Username=postgres;Password=PostgreSQL");
        }
    }
}
