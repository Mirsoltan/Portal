using Entities.HISEntities.PatientEntity;
using Entities.HISEntities.ServicesEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.HIS.PatientServiceMappings
{
    public static class PatientServiceConfigs
    {
        public static void ApplyPatientServicesConfig(this ModelBuilder modelBuilder)
        {
            #region MasterService
            modelBuilder.Entity<MasterService>().ToTable(name: typeof(MasterService).Name, schema: Schemas.SchemaHIS);
            modelBuilder.Entity<MasterService>().Property(x => x.MasterServiceName).HasMaxLength(300);
            modelBuilder.Entity<MasterService>().Property(x => x.NationalCode).HasMaxLength(6);
            modelBuilder.Entity<MasterService>().Property(x => x.ServiceDisplayName).HasMaxLength(500);
            modelBuilder.Entity<MasterService>().HasOne(x => x.MasterServices).WithMany(m => m.MServices).HasForeignKey(f => f.MSParentID);
            modelBuilder.Entity<MasterService>().HasOne(x => x.ServiceGroupCategory).WithMany(m => m.MasterService).HasForeignKey(f => f.ServiceGroupCategoryID);
            #endregion

            #region MasterServiceGroupCategory
            modelBuilder.Entity<MasterServiceGroupCategory>().ToTable(name: typeof(MasterServiceGroupCategory).Name, schema: Schemas.SchemaHIS);
            modelBuilder.Entity<MasterServiceGroupCategory>().Property(x => x.MSCategoryName).HasMaxLength(300);
            modelBuilder.Entity<MasterServiceGroupCategory>().HasOne(x => x.Category)
                .WithMany(m => m.SubCategory).HasForeignKey(f => f.MSGParentID);
            #endregion

        }
    }
}
