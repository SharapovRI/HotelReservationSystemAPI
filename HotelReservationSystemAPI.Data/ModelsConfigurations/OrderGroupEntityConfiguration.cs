using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class OrderGroupEntityConfiguration : IEntityTypeConfiguration<OrderGroupEntity>
    {
        public void Configure(EntityTypeBuilder<OrderGroupEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.PersonId)
                .IsRequired();

            builder.HasOne(p => p.Person)
                .WithMany(p => p.OrderGroups)
                .HasForeignKey(p => p.PersonId);
            builder.HasMany(p => p.Orders)
                .WithOne(p => p.OrderGroup)
                .HasForeignKey(p => p.OrderGroupId);
        }
    }
}
