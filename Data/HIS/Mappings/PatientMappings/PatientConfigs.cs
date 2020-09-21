using Entities.HISEntities.PatientEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.HIS.PatientMappings
{
    public static class PatientConfigs
    {
        public static void ApplyPatientConfig(this ModelBuilder builder)
        {
            builder.Entity<Patient>().ToTable(name: typeof(Patient).Name, schema: Schemas.SchemaHIS);
            builder.Entity<Patient>().Property(x => x.FirstName).HasMaxLength(50);
            builder.Entity<Patient>().Property(x => x.LastName).HasMaxLength(50);
            builder.Entity<Patient>().Property(x => x.FatherName).HasMaxLength(50);
            builder.Entity<Patient>().Property(x => x.NationalCode).HasMaxLength(10);
            builder.Entity<Patient>().Property(x => x.HomeTel).HasMaxLength(11);
            builder.Entity<Patient>().Property(x => x.TelNo1).HasMaxLength(11);
            builder.Entity<Patient>().Property(x => x.Mobile).HasMaxLength(11);
            builder.Entity<Patient>().Property(x => x.Address).HasMaxLength(700);
            builder.Entity<Patient>().Property(x => x.BirthPlace).HasMaxLength(50);

        }
    }

    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(name: typeof(Patient).Name, schema: Schemas.SchemaHIS);
        }

    }
}
