using Grpc.ProductManagement.Context;
using Grpc.ProductManagement.Enums;
using Grpc.ProductManagement.IRepositories;
using Grpc.ProductManagement.IServices;
using Grpc.ProductManagement.Models;
using Grpc.ProductManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Services
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;
        /*private readonly UserManager<Student> _userManager;*/
        //private readonly IMapper _mapper;
        private readonly IRoleRepository _appRoleRepository;
        //private IHomeRepository _ihomeRepo;
        private readonly AppDbContext _dbContext;
        public RoleService(/*UserManager<Student> userManager,*/ IUnitOfWork unitOfWork, AppDbContext dbContext, IRoleRepository appRoleRepository)
        {
            /*_userManager = userManager;*/
            _unitOfWork = unitOfWork;

            _appRoleRepository = appRoleRepository;
            _dbContext = dbContext;

        }

        public bool Add(Role appRole)
        {
            _appRoleRepository.Add(appRole);

            return true;
        }

        public async Task<Role> GetAppRoleAsync()
        {
            var result = _appRoleRepository.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();


            if (result.Count > 0)
            {
                return result[0];
            }
            return null;
        }

        public Role Update([FromBody] RoleModel app)
        {
            var entity = _appRoleRepository.FindAll(x => x.RoleId == app.RoleId).FirstOrDefault();
            entity.RoleId = app.RoleId;
            entity.RoleName = app.RoleName;
            _appRoleRepository.Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            _appRoleRepository.Remove(id);
        }
    }
}
