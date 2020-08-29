using Entities.SupervisionEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings.SupervisionMappings
{
    public class SupervisionMapping : IEntityTypeConfiguration<SupervisionEntity>
    {
        public void Configure(EntityTypeBuilder<SupervisionEntity> builder)
        {
            builder.Property(n => n.Name).HasMaxLength(200).IsRequired().IsUnicode();
            builder.Property(c => c.Code).HasMaxLength(50);
            builder.Property(d => d.Detailes).HasMaxLength(1000).IsUnicode();
        }
    }
}
