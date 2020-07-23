using Grpc.AccountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.IRepositories
{
    public interface IRolePerRepository : IRepository<RolePermission>
    {
    }
}
