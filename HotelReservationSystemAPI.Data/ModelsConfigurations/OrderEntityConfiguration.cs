using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.RoomId)
                .IsRequired();
            builder.Property(p => p.PersonId)
                .IsRequired();
            builder.Property(p => p.Cost)
                .IsRequired();
            builder.Property(p => p.CheckInTime)
                .IsRequired();
            builder.Property(p => p.CheckOutTime)
                .IsRequired();

            builder.HasOne(p => p.Person)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.PersonId);
            builder.HasOne(p => p.Room)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.RoomId);
            builder.HasMany(p => p.AdditionalFacilities)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId);
        }
    }
}