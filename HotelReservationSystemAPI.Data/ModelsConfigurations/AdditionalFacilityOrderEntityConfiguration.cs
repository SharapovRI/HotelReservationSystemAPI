using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class AdditionalFacilityOrderEntityConfiguration : IEntityTypeConfiguration<AdditionalFacilityOrderEntity>
    {
        public void Configure(EntityTypeBuilder<AdditionalFacilityOrderEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.AdditionFacilityId)
                .IsRequired();
            builder.Property(p => p.OrderId)
                .IsRequired();

            builder.HasOne(p => p.AdditionalFacility)
                .WithMany(p => p.FacilityOrders)
                .HasForeignKey(p => p.AdditionFacilityId);
            builder.HasOne(p => p.Order)
                .WithMany(p => p.AdditionalFacilities)
                .HasForeignKey(p => p.OrderId);
        }
    }
}
