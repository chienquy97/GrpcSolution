using Grpc.AccountManagement.Context;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Repositories
{
    public class RoleRepository : EFRepository<AppRole>, IRoleRepository
    {
        private AppDbContext _appContext;
        public RoleRepository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }
    }
}
