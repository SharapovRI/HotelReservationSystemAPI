using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class HotelEntityConfiguration : IEntityTypeConfiguration<HotelEntity>
    {
        public void Configure(EntityTypeBuilder<HotelEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.CountryId)
                .IsRequired();
            builder.Property(p => p.CityId)
                .IsRequired();
            builder.Property(p => p.Address)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasOne(p => p.Country)
                .WithMany(p => p.Hotels)
                .HasForeignKey(p => p.CountryId);
            builder.HasOne(p => p.City)
                .WithMany(p => p.Hotels)
                .HasForeignKey(p => p.CityId);
            builder.HasMany(p => p.Rooms)
                .WithOne(p => p.Hotel)
                .HasForeignKey(p => p.HotelId);
            builder.HasMany(p => p.RoomsCosts)
                .WithOne(p => p.Hotel)
                .HasForeignKey(p => p.HotelId);
            builder.HasMany(p => p.FacilitiesCosts)
                .WithOne(p => p.Hotel)
                .HasForeignKey(p => p.HotelId);
        }
    }
}