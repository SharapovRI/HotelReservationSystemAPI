using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class RoomPhotoConfiguration : IEntityTypeConfiguration<RoomPhotoEntity>
    {
        public void Configure(EntityTypeBuilder<RoomPhotoEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.Title)
                .IsRequired();
            builder.Property(p => p.Data)
                .IsRequired();

            builder.HasMany(p => p.RoomsLinks)
                .WithOne(p => p.RoomPhoto)
                .HasForeignKey(p => p.PhotoId);
        }
    }
}