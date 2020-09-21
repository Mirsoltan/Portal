using Entities.HelpDesk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.HelpDesk
{
    public class RequestWardMapping : IEntityTypeConfiguration<RequestWard>
    {
        public void Configure(EntityTypeBuilder<RequestWard> builder)
        {
            builder.ToTable(name: typeof(RequestWard).Name, schema: Schemas.SchemaHDIS);
            builder.Property(d => d.Description).HasMaxLength(1000).IsRequired().IsUnicode();
            builder.Property(d => d.Title).HasMaxLength(500).IsRequired().IsUnicode();

            //builder.HasKey(m => new { m.Id, m.DemanderLocationId, m.RecepterLocationId });

            //بخش درخواست کننده 
            builder.HasOne(l => l.DemanderWard).WithMany(w => w.DemanderWards)
                .HasForeignKey(f => f.DemanderWardID).OnDelete(DeleteBehavior.Restrict);
            // بخش اقدام کننده - پذیرنده
            builder.HasOne(l => l.RecepterWard).WithMany(w => w.RecepterWards)
                .HasForeignKey(f => f.RecepterWardID).OnDelete(DeleteBehavior.Restrict);

            // چرخه درخواست 
            builder.HasOne(l => l.requestWard).WithMany(w => w.ReferRequestWard)
                .HasForeignKey(f => f.ParentRequestWardID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
