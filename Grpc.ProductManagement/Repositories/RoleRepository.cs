using Grpc.ProductManagement.Context;
using Grpc.ProductManagement.IRepositories;
using Grpc.ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Repositories
{
    public class RoleRepository : EFRepository<Role, int>, IRoleRepository
    {
        private AppDbContext _appContext;
        public RoleRepository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }
    }
}
