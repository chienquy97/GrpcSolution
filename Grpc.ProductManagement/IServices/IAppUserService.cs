using Grpc.ProductManagement.Entitis;
using Grpc.ProductManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.IServices
{
    public interface IAppUserService
    {
        Task<object> GetById(Guid id);
        Task<IdentityResult> AddAsync(AppUserModel userVm);
    }
}
