using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class RoomsCostEntityConfiguration : IEntityTypeConfiguration<RoomsCostEntity>
    {
        public void Configure(EntityTypeBuilder<RoomsCostEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.TypeId)
                .IsRequired();
            builder.Property(p => p.HotelId)
                .IsRequired();
            builder.Property(p => p.Cost)
                .IsRequired();

            builder.HasOne(p => p.RoomType)
                .WithMany(p => p.RoomsCosts)
                .HasForeignKey(p => p.TypeId);
            builder.HasOne(p => p.Hotel)
                .WithMany(p => p.RoomsCosts)
                .HasForeignKey(p => p.HotelId);
        }
    }
}