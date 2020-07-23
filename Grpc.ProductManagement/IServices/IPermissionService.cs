using Grpc.ProductManagement.Models;
using Grpc.ProductManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.IServices
{
    public interface IPermissionService
    {
        bool Add(Permission student);
        Task<Permission> GetPermissionAsync();
        Permission Update([FromBody] PermissionModel permission);
        void Delete(int id);
    }
}
