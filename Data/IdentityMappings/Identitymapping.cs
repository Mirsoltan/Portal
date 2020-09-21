using Entities.HISEntities.PractitionerEntity;
using Entities.identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IdentityMappings
{
    public static class IdentityMapping
    {
        public static void ApplyCustomIdentityConfigs(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("AppUsers",schema:Schemas.SchemaUIS);
            modelBuilder.Entity<Role>().ToTable("AppRoles", schema: Schemas.SchemaUIS);
            modelBuilder.Entity<UserRole>().ToTable("AppUserRole", schema: Schemas.SchemaUIS);
            modelBuilder.Entity<RoleClaim>().ToTable("AppRoleClaim", schema: Schemas.SchemaUIS);
            modelBuilder.Entity<UserClaim>().ToTable("AppUserClaim", schema: Schemas.SchemaUIS);

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users).HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserRole>()
               .HasOne(userRole => userRole.User)
               .WithMany(role => role.Roles).HasForeignKey(r => r.UserId);

            modelBuilder.Entity<RoleClaim>()
                 .HasOne(roleclaim => roleclaim.Role)
                 .WithMany(claim => claim.Claims).HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<UserClaim>()
                .HasOne(userClaim => userClaim.User)
                .WithMany(claim => claim.Claims).HasForeignKey(c => c.UserId);


            modelBuilder.Entity<User>().Property(p => p.FirstName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.LastName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.Address).HasMaxLength(700);
            modelBuilder.Entity<User>().Property(p => p.HomeTel).HasMaxLength(11);
            modelBuilder.Entity<User>().Property(p => p.PhoneNumber).HasMaxLength(11);
            modelBuilder.Entity<User>().Property(p => p.Mobile).HasMaxLength(11);
            modelBuilder.Entity<User>().Property(p => p.TelNo1).HasMaxLength(11);
            modelBuilder.Entity<User>().Property(p => p.Bio).HasMaxLength(500);
            modelBuilder.Entity<User>().Property(p => p.FatherName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.BirthPlace).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.NationalCode).HasMaxLength(10);
            modelBuilder.Entity<User>().Property(p => p.NormalizedUserName).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.RegisterationNo).HasMaxLength(10);
            modelBuilder.Entity<User>().Property(p => p.UserName).HasMaxLength(20);
        }
    }
}
