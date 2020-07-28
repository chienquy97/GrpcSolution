using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Repositories
{
    public class UserRoleRepository : EFRepository<UserRole>, IUserRoleRepository
    {
        private AppDbContext _appContext;
        public UserRoleRepository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }
    }
}
