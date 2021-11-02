using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.TypeId)
                .IsRequired();
            builder.Property(p => p.HotelId)
                .IsRequired();
            builder.Property(p => p.LastView)
                .IsRequired(false);

            builder.HasOne(p => p.RoomType)
                .WithMany(p => p.Rooms)
                .HasForeignKey(p => p.TypeId);
            builder.HasOne(p => p.Hotel)
                .WithMany(p => p.Rooms)
                .HasForeignKey(p => p.HotelId);
            builder.HasMany(p => p.Orders)
                .WithOne(p => p.Room)
                .HasForeignKey(p => p.RoomId);
        }
    }
}