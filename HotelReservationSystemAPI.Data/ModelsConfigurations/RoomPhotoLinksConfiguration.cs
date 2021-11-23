using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class RoomPhotoLinksConfiguration : IEntityTypeConfiguration<RoomPhotoLinksEntity>
    {
        public void Configure(EntityTypeBuilder<RoomPhotoLinksEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.RoomId)
                .IsRequired();
            builder.Property(p => p.PhotoId)
                .IsRequired();

            builder.HasOne(p => p.Room)
                .WithMany(p => p.PhotoLinks)
                .HasForeignKey(p => p.RoomId);
            builder.HasOne(p => p.RoomPhoto)
                .WithMany(p => p.RoomsLinks)
                .HasForeignKey(p => p.PhotoId);
        }
    }
}