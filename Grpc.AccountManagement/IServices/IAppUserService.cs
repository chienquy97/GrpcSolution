using Grpc.AccountManagement.Entitis;
using Grpc.AccountManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.IServices
{
    public interface IAppUserService
    {
        List<AppUser> GetAll();
        AppUserModel GetByIdd(Guid id);
        Task<object> GetById(Guid id);
        Task<IdentityResult> AddAsync(AppUserlCreateViewMode userVm);
        void Delete(int id);
        Task<AppUser> Update([FromBody] AppUserModel app);
    }
}
