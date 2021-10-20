using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Data
{
    public class NpgsqlContext : DbContext //-Project HotelReservationSystemAPI.Data
    {
        public DbSet<AdditionalServiceEntity> additional_services { get; set; }
        public DbSet<AdditionalServicesInOrderEntity> additional_services_in_orders { get; set; }
        public DbSet<CostOfRoomsEntity> cost_of_rooms { get; set; }
        public DbSet<CostsOfServicesEntity> costs_of_services { get; set; }
        public DbSet<HotelEntity> hotels { get; set; }
        public DbSet<OrderEntity> orders { get; set; }
        public DbSet<PersonEntity> persons { get; set; }
        public DbSet<RoleEntity> roles { get; set; }
        public DbSet<RoomEntity> rooms { get; set; }
        public DbSet<TypesOfRoomsEntity> types_of_rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HotelReservationSystemAPI_DB;Username=postgres;Password=PostgreSQL");
        }
    }
}
