using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class HotelPhotoEntityConfiguration : IEntityTypeConfiguration<HotelPhotoEntity>
    {
        public void Configure(EntityTypeBuilder<HotelPhotoEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.Title)
                .IsRequired();
            builder.Property(p => p.Data)
                .IsRequired();

            builder.HasOne(p => p.Hotel)
                .WithMany(p => p.Photos)
                .HasForeignKey(p => p.HotelId);
        }
    }
}
