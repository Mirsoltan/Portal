using Data.HelpDesk;
using Data.HIS.AdmissionMappings;
using Data.HIS.PatientMappings;
using Data.HIS.PatientServiceMappings;
using Data.HIS.PractitionerMappings;
using Data.IdentityMappings;
using Data.Mappings.HomeMappings;
using Data.Mappings.LocationMapping;
using Entities.HelpDesk;
using Entities.HISEntities.PatientEntity;
using Entities.HISEntities.PractitionerEntity;
using Entities.HISEntities.ServicesEvents;
using Entities.HomeEntities;
using Entities.identity;
using Entities.LocationsEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class PortalDbContext : IdentityDbContext<User,
        Role, int, UserClaim, UserRole, IdentityUserLogin<int>, RoleClaim, IdentityUserToken<int>>
    {
        public PortalDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Identity
            builder.ApplyCustomIdentityConfigs();
            builder.Entity<User>().Property(b => b.RegisterDateTime).HasDefaultValueSql("GetDate()");
            //builder.Entity<User>().Property(b => b.RegisterDateTime).HasDefaultValueSql("CONVERT(DATETIME, CONVERT(VARCHAR(20),GetDate(), 120))");
            builder.Entity<User>().Property(b => b.IsActive).HasDefaultValueSql("1");
            #endregion

            #region Location
            builder.ApplyLocationConfig();
            #endregion

            #region LocalApplications
            builder.ApplyLocalApplicationsConfig();
            #endregion

            #region RequestWard
            builder.ApplyRequestWardConfig();
            #endregion

            #region His
            #region Admission
            builder.ApplyAdmissionConfig();
            #endregion
            #region Patient
            builder.ApplyPatientConfig();
            #endregion
            #region Doctors
            builder.ApplyDoctorsConfig();
            #endregion
            #region PatientServices

            #endregion
            #endregion
        }

        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<LocalApplications> LocalApplications { get; set; }

        #region RequestWard
        public virtual DbSet<RequestWard> RequestWard { get; set; }
        #endregion


        #region HIS

        #region Doctors
        public virtual DbSet<Doctors> Doctors { get; set; }
        #endregion

        #region Patient
        public virtual DbSet<Patient> Patients { get; set; }
        #endregion

        #region Admission
        public virtual DbSet<Admission> Admissions { get; set; }

        #endregion
        #region PatientServices
        public virtual DbSet<MasterService> MasterServices { get; set; }
        public virtual DbSet<MasterServiceGroupCategory> MasterServiceGroupCategory { get; set; }
        #endregion
        #endregion
    }
}
