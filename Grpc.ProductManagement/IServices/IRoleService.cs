using Grpc.ProductManagement.Models;
using Grpc.ProductManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.IServices
{
    public interface IRoleService
    {
        bool Add(Role appRole);
        Task<Role> GetAppRoleAsync();
        Role Update([FromBody] RoleModel app);
        void Delete(int id);
    }
}
