using Grpc.ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.IRepositories
{
    public interface IRolePerRepository : IRepository<RolePermission, int>
    {
    }
}
