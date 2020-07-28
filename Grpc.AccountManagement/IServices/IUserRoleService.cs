using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.IServices
{
    public interface IUserRoleService
    {
        List<UserRole> AddUserRole(UserRoleViewModel userRole);
        Task<UserRole> GetUserRoleAsync();
        //Task<UserRole> GetUserRoleAsync();
    }
}
