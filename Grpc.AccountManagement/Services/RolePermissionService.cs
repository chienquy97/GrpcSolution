using AutoMapper;
using Grpc.AccountManagement.Enums;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.IServices;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRolePermissionRepository _rolePermission;
        private readonly IRoleRepository _roleRepository;
        private readonly AppDbContext _dbContext;

        public RolePermissionService(IRoleRepository roleRepository, IPermissionRepository permissionRepository, IUnitOfWork unitOfWork, AppDbContext dbContext, IRolePermissionRepository rolePermission, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _permissionRepository = permissionRepository;
            _dbContext = dbContext;
            _rolePermission = rolePermission;
            _roleRepository = roleRepository;
        }

        public List<RolePermission> AddRolePermission(RolePermissionViewModel userRole)
        {
            var userRoles = new List<RolePermission>();
            foreach (var item in userRole.PerIds)
            {
                var data = new RolePermission();
                data.PerId = item;
                data.RoleId = userRole.RoleId;
                userRoles.Add(data);
            }
            _rolePermission.AddRange(userRoles);
            SaveChanges();
            return userRoles;
        }

        public async Task<bool> Update(RoleModel app)
        {
            //Delete previous roles
            var rolesInDb = _dbContext.RolePermission.Where(x => x.RoleId == app.Id);
            _dbContext.RolePermission.RemoveRange(rolesInDb);

            //Update new roles
            foreach (var perId in app.PerIds)
            {
                _dbContext.RolePermission.Add(new RolePermission { RoleId = (Guid)app.Id, PerId = perId });
            }
            SaveChanges();
            return true;
        }

        public List<RolePermission> GetAll()
        {
            var user = _rolePermission.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();
            return user;
        }
        private void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
