using Entities.LocationsEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings.LocationMapping
{
    public static class LocationConfigs
    {
        public static void ApplyLocationConfig(this ModelBuilder modelbuilder)
        {

            modelbuilder.ApplyConfiguration(new LocationMapping());
        }
    }

    public class LocationMapping : IEntityTypeConfiguration<Locations>
    {
        public void Configure(EntityTypeBuilder<Locations> builder)
        {
            builder.Property(n => n.LocationName).HasMaxLength(200).IsRequired().IsUnicode();
            
            builder.HasOne(l => l.location).WithMany(m => m.LocationS)
                .HasForeignKey(f => f.ParentLocationID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
