using Data.IdentityMappings;
using Data.Mappings.OrbitMappings;
using Data.Mappings.SupervisionMappings;
using Entities.identity;
using Entities.LocationsEntities;
using Entities.SupervisionEntities;
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
            builder.Entity<User>().Property(b => b.RegisterDateTime).HasDefaultValueSql("CONVERT(DATETIME, CONVERT(VARCHAR(20),GetDate(), 120))");
            builder.Entity<User>().Property(b => b.IsActive).HasDefaultValueSql("1");
            #endregion

           
            #region Supervision
            builder.ApplySupervisionConfig();
            builder.ApplyOrbitConfig();
            #endregion

            //builder.Entity<News>().Property(b => b.PublishDateTime).HasDefaultValueSql("CONVERT(datetime,GetDate())");
        }

        #region Supervision
        public virtual DbSet<SupervisionEntity> Supervisions { get; set; }
        public virtual DbSet<Orbit> Orbits { get; set; }
        public virtual DbSet<LocationEntity> LocationEntities { get; set; }
        public virtual DbSet<LocationCategory> LocationCategories { get; set; }
        #endregion

        #region MyRegion

        #endregion
    }
}
