using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.IServices
{
    public interface IRoleService
    {
        //List<AppRole> Add(List<RoleCreateViewModel> Vm);
        List<AppRole> GetAll();
        RoleModel GetById(Guid id);
        bool Add(AppRole appRole);
        Task<AppRole> GetAppRoleAsync();
        AppRole Update([FromBody] RoleModel app);
        void Delete(int id);
    }
}
