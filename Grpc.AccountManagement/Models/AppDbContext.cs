using Grpc.AccountManagement.Entitis;
using Grpc.AccountManagement.SharedCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
               .Where(x => x.Entity is IDomainEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IDomainEntity)entry.Entity;
                DateTime now = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entity.DateCreated = now;
                }
                else
                {
                    base.Entry(entity).Property(x => x.DateCreated).IsModified = false;
                }

                entity.DateModified = now;
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
                .HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
               .HasKey(x => new { x.UserId });
            #endregion Identity Config
        }
    }
}
