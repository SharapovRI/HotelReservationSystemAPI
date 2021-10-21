using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data
{
    public class NpgsqlContext : DbContext //-Project HotelReservationSystemAPI.Data
    {
        public DbSet<AdditionalFacilityEntity> AdditionalFacilities { get; set; }
        public DbSet<AdditionalFacilityOrderEntity> AdditionalFacilitiesInOrders { get; set; }
        public DbSet<RoomsCostEntity> RoomsCosts { get; set; }
        public DbSet<ServiceCostEntity> ServiceCosts { get; set; }
        public DbSet<HotelEntity> Hotel { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<RoomTypeEntity> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HotelReservationSystemAPI_DB;Username=postgres;Password=PostgreSQL");
        }
    }
}
