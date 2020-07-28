using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.IServices
{
    public interface IPermissionService
    {
        bool Add(Permission permission);
        Task<Permission> GetPermissionAsync();
        Permission Update([FromBody] PermissionModel permission);
        void Delete(int id);
    }
}
