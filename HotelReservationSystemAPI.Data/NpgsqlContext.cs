using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data
{
    public class NpgsqlContext : DbContext //-Project HotelReservationSystemAPI.Data
    {
        public DbSet<AdditionalFacilityEntity> AdditionalFacilities { get; set; }
        public DbSet<AdditionalFacilityOrderEntity> AdditionalFacilitiesInOrders { get; set; }
        public DbSet<RoomsCostEntity> RoomsCosts { get; set; }
        public DbSet<FacilityCostEntity> FacilityCosts { get; set; }
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<RoomTypeEntity> RoomTypes { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                .UseNpgsql("Host=localhost;Port=5432;Database=HotelReservationSystemAPI_DB;Username=postgres;Password=PostgreSQL");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdditionalFacilityEntityConfiguration())
                .ApplyConfiguration(new AdditionalFacilityOrderEntityConfiguration())
                .ApplyConfiguration(new CityEntityConfiguration())
                .ApplyConfiguration(new CountryEntityConfiguration())
                .ApplyConfiguration(new FacilityCostEntityConfiguration())
                .ApplyConfiguration(new HotelEntityConfiguration())
                .ApplyConfiguration(new OrderEntityConfiguration())
                .ApplyConfiguration(new PersonEntityConfiguration())
                .ApplyConfiguration(new RoleEntityConfiguration())
                .ApplyConfiguration(new RoomEntityConfiguration())
                .ApplyConfiguration(new RoomsCostEntityConfiguration())
                .ApplyConfiguration(new RoomTypeEntityConfiguration());
        }
    }
}
