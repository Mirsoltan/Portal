using Entities.HISEntities.PatientEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Settings;

namespace Data.HIS.AdmissionMappings
{
    public static class AdmissionConfigs
    {
        public static void ApplyAdmissionConfig(this ModelBuilder builder)
        {

            //modelbuilder.ApplyConfiguration(new AdmissionMapping());

            builder.Entity<Admission>().ToTable(name: typeof(Admission).Name, schema: Schemas.SchemaHIS);

            builder.Entity<Admission>()
                .HasOne(l => l.Locations).WithMany(m => m.Admissions)
                .HasForeignKey(f => f.LocationID).OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// کاربر پذیرش کننده
            /// </summary>
            builder.Entity<Admission>()
                .HasOne(l => l.Users).WithMany(m => m.AdmissionUsers)
                .HasForeignKey(f => f.UserID).OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// پزشک انجام دهنده
            /// </summary>
            builder.Entity<Admission>()
               .HasOne(l => l.Practitioners).WithMany(m => m.Practitioners)
               .HasForeignKey(f => f.PractitionerID).OnDelete(DeleteBehavior.Restrict);


            /// <summary>
            /// پزشک درخواست کننده
            /// </summary>
            builder.Entity<Admission>()
                .HasOne(l => l.Doctors).WithMany(m => m.Admissions)
                .HasForeignKey(f => f.DoctorID).OnDelete(DeleteBehavior.Restrict);



        }
    }

    public class AdmissionMapping : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {
            builder.HasOne(l => l.Locations).WithMany(m => m.Admissions)
                .HasForeignKey(f => f.LocationID).OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(l => l.Practitioners).WithMany(m => m.Admissions)
            //    .HasForeignKey(f => f.PractitionerID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
