using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.IServices
{
    public interface IRolePermissionService
    {
        List<RolePermission> AddRolePermission(RolePermissionViewModel userRole);
        List<RolePermission> GetAll();
        Task<bool> Update(RoleModel app);
    }
}
