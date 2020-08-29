using Entities.LocationsEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Data.Mappings.OrbitMappings
{
    public class OrbitMapping : IEntityTypeConfiguration<Orbit>
    {
        public void Configure(EntityTypeBuilder<Orbit> builder)
        {
            builder.Property(n => n.OrbitName).HasMaxLength(200).IsRequired().IsUnicode();
            builder.Property(c => c.TelNo1).HasMaxLength(50);
            builder.Property(c => c.TelNo2).HasMaxLength(50);
        }
    }
    public class LocationEntitiesMapping : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.Property(n => n.Name).HasMaxLength(200).IsRequired().IsUnicode();
            builder.Property(n => n.Title).HasMaxLength(200).IsRequired().IsUnicode();
            builder.Property(c => c.strIcon).HasMaxLength(50);
            builder.HasOne(x => x.Orbit).WithMany(m => m.locationEntities).HasForeignKey(f => f.OrbitId);        
            builder.HasOne(x => x.LocationCategory).WithMany(m => m.LocationEntities)
                .HasForeignKey(f => f.LocationCategoryId).OnDelete(DeleteBehavior.Restrict);        
        }
    }

    public class LocationCategoryMapping : IEntityTypeConfiguration<LocationCategory>
    {
        public void Configure(EntityTypeBuilder<LocationCategory> builder)
        {
            builder.Property(n => n.Title).HasMaxLength(200).IsRequired().IsUnicode();
            
        }
    }
}
