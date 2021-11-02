using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class FacilityCostEntityConfiguration : IEntityTypeConfiguration<FacilityCostEntity>
    {
        public void Configure(EntityTypeBuilder<FacilityCostEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.AdditionalFacilityId)
                .IsRequired();
            builder.Property(p => p.HotelId)
                .IsRequired();
            builder.Property(p => p.Cost)
                .IsRequired();

            builder.HasOne(p => p.AdditionalFacility)
                .WithMany(p => p.FacilityCosts)
                .HasForeignKey(p => p.AdditionalFacilityId);
            builder.HasOne(p => p.Hotel)
                .WithMany(p => p.FacilitiesCosts)
                .HasForeignKey(p => p.HotelId);
        }
    }
}