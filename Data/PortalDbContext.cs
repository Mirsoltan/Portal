using Data.IdentityMappings;
using Data.Mappings.LocationMapping;
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

            #region RequestWard

            #endregion
        }

        public virtual DbSet<Location> Locations { get; set; }

        #region RequestWard

        #endregion
    }
}
