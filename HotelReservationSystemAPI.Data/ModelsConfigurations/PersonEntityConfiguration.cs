using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.RoleId)
                .IsRequired();
            builder.Property(p => p.Login)
                .IsRequired();
            builder.Property(p => p.Password)
                .IsRequired();
            builder.OwnsOne(p => p.RefreshToken);

            builder.HasOne(p => p.Role)
                .WithMany(p => p.Persons)
                .HasForeignKey(p => p.RoleId);
            builder.HasMany(p => p.Orders)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);
        }
    }
}