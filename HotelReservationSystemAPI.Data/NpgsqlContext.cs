using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Data
{
    public class NpgsqlContext : DbContext //-Project HotelReservationSystemAPI.Data
    {
        public DbSet<AdditionalService> additional_services { get; set; }
        public DbSet<AdditionalServicesInOrder> additional_services_in_orders { get; set; }
        public DbSet<CostOfRooms> cost_of_rooms { get; set; }
        public DbSet<CostsOfServices> costs_of_services { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Person> persons { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<TypesOfRooms> types_of_rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HotelReservationSystemAPI_DB;Username=postgres;Password=PostgreSQL");
        }
    }
}
