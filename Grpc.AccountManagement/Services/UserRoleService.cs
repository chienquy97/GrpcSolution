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
    public class UserRoleService : IUserRoleService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepo;
        private readonly AppDbContext _dbContext;
        public UserRoleService(IUserRoleRepository userRoleRepo, IUnitOfWork unitOfWork, AppDbContext dbContext, IRoleRepository roleRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _dbContext = dbContext;
            _userRoleRepo = userRoleRepo;
        }
        public List<AppRole> GetAll()
        {
            var role = _roleRepository.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();
            return role;
        }
        public List<UserRole> AddUserRole(UserRoleViewModel userRole)
        {
            var userRoles = new List<UserRole>();
            foreach (var item in userRole.RoleIds)
            {
                var data = new UserRole();
                data.RoleId = item.RoleId;
                data.UserId = userRole.UserId;
                userRoles.Add(data);
            }
            _userRoleRepo.AddRange(userRoles);
            SaveChanges();
            return userRoles;
        }

        public async Task<UserRole> GetUserRoleAsync()
        {
            var result = _userRoleRepo.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();


            if (result.Count > 0)
            {
                return result[0];
            }
            return null;
        }

        private void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
