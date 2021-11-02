using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class RoomTypeEntityConfiguration : IEntityTypeConfiguration<RoomTypeEntity>
    {
        public void Configure(EntityTypeBuilder<RoomTypeEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.SeatsCount)
                .IsRequired();
            
            builder.HasMany(p => p.Rooms)
                .WithOne(p => p.RoomType)
                .HasForeignKey(p => p.TypeId);
            builder.HasMany(p => p.RoomsCosts)
                .WithOne(p => p.RoomType)
                .HasForeignKey(p => p.TypeId);
        }
    }
}