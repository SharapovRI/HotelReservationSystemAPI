using System;
using System.Collections.Generic;
using System.Text;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystemAPI.Data.ModelsConfigurations
{
    public class AdditionalFacilityEntityConfiguration : IEntityTypeConfiguration<AdditionalFacilityEntity>
    {
        public void Configure(EntityTypeBuilder<AdditionalFacilityEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasMany(p => p.FacilityCosts)
                .WithOne(p => p.AdditionalFacility)
                .HasForeignKey(p => p.AdditionalFacilityId);
        }
    }
}
