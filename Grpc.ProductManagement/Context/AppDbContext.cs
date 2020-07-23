using Grpc.ProductManagement.Entitis;
using Grpc.ProductManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> UserUser { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
