using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class AdditionalFacilityEntityConfiguration : IEntityTypeConfiguration<AdditionalFacilityEntity>
    {
        public void Configure(EntityTypeBuilder<AdditionalFacilityEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.HotelId)
                .IsRequired();
            builder.Property(p => p.Cost)
                .IsRequired();
            builder.Property(p => p.IsActive);

            builder.HasOne(p => p.Hotel)
                .WithMany(p => p.FacilitiesCosts)
                .HasForeignKey(p => p.HotelId);
            builder.HasMany(p => p.FacilityOrders)
                .WithOne(p => p.AdditionFacility)
                .HasForeignKey(p => p.AdditionFacilityId);
        }
    }
}