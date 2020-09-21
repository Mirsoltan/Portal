using Entities.HomeEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings.HomeMappings
{
    public static class LocalApplicationsConfigs
    {
        public static void ApplyLocalApplicationsConfig(this ModelBuilder builder)
        {

            //modelbuilder.ApplyConfiguration(new AdmissionMapping());

            builder.Entity<LocalApplications>().ToTable(name: typeof(LocalApplications).Name, schema: Schemas.SchemaHIS);

            //builder.Entity<LocalApplications>().Property(x => x.InsertDate).HasDefaultValueSql("CONVERT(datetime,GetDate())");
            builder.Entity<LocalApplications>().Property(B => B.ApplicationPath).IsRequired().HasMaxLength(1000);
            builder.Entity<LocalApplications>().Property(B => B.Description).HasMaxLength(500);
            builder.Entity<LocalApplications>().Property(B => B.Title).IsRequired().HasMaxLength(300);
            builder.Entity<LocalApplications>().Property(p => p.Image).HasColumnType("image");
        }
    }
}
