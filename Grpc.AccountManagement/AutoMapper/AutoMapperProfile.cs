using AutoMapper;
using Grpc.AccountManagement.Entitis;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleCreateViewModel, AppRole>().ReverseMap();
            CreateMap<AppRole, RoleCreateViewModel>().ReverseMap();
            CreateMap<RoleModel, AppRole>().ReverseMap();
            CreateMap<AppRole, RoleModel>().ReverseMap();
            CreateMap<AppUserlCreateViewMode, AppUser>().ReverseMap();
            CreateMap<AppUser, AppUserlCreateViewMode>().ReverseMap();
            CreateMap<AppUserModel, AppUser>().ReverseMap();
            CreateMap<AppUser, AppUserModel>().ReverseMap();
            CreateMap<Permission, PermissionModel>().ReverseMap();
            CreateMap<PermissionModel, Permission>().ReverseMap();
            CreateMap<UserRole, UserRoleViewModel>().ReverseMap();
            CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
            //CreateMap<RolePerViewModel, RolePermission>().ReverseMap();
            //CreateMap<RolePermission, RolePerViewModel>().ReverseMap();
        }
    }
}
