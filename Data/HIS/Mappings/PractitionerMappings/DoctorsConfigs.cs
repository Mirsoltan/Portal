using Entities.HISEntities.PractitionerEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.HIS.PractitionerMappings
{
    public static class DoctorsConfigs
    {
        public static void ApplyDoctorsConfig(this ModelBuilder modelBuilder)
        {

            //modelbuilder.ApplyConfiguration(new PractitionerMapping());
            modelBuilder.Entity<Doctors>().ToTable(name: typeof(Doctors).Name, schema: Schemas.SchemaHIS);

            modelBuilder.Entity<Doctors>().Property(p => p.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Doctors>().Property(p => p.LastName).HasMaxLength(50);
            modelBuilder.Entity<Doctors>().Property(p => p.Address).HasMaxLength(700);
            modelBuilder.Entity<Doctors>().Property(p => p.HomeTel).HasMaxLength(11);
            modelBuilder.Entity<Doctors>().Property(p => p.Mobile).HasMaxLength(11);
            modelBuilder.Entity<Doctors>().Property(p => p.TelNo1).HasMaxLength(11);
            modelBuilder.Entity<Doctors>().Property(p => p.FatherName).HasMaxLength(50);
            modelBuilder.Entity<Doctors>().Property(p => p.BirthPlace).HasMaxLength(50);
            modelBuilder.Entity<Doctors>().Property(p => p.NationalCode).HasMaxLength(10);
            modelBuilder.Entity<Doctors>().Property(p => p.RegisterationNo).HasMaxLength(10);
        }
    }

    public class PractitionerMapping : IEntityTypeConfiguration<Doctors>
    {
        public void Configure(EntityTypeBuilder<Doctors> builder)
        {
            builder.ToTable(name: typeof(Doctors).Name, schema: Schemas.SchemaHIS);
        }

    }
}
