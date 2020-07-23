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
    public class PermissionService : IPermissionService
    {
      
        private IUnitOfWork _unitOfWork;
        /*private readonly UserManager<Student> _userManager;*/
        //private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;
        //private IHomeRepository _ihomeRepo;
        private readonly AppDbContext _dbContext;
        public PermissionService(/*UserManager<Student> userManager,*/ IUnitOfWork unitOfWork, AppDbContext dbContext, IPermissionRepository permissionRepository)
        {
            /*_userManager = userManager;*/
            _unitOfWork = unitOfWork;

            _permissionRepository = permissionRepository;
            _dbContext = dbContext;

        }
        public bool Add(Permission student)
        {
            _permissionRepository.Add(student);
            
            return true;
        }

        public void Delete(int id)
        {
            _permissionRepository.Remove(id);
        }

        public async Task<Permission> GetPermissionAsync()
        {
            var result = _permissionRepository.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();


            if (result.Count > 0)
            {
                return result[0];
            }
            return null;
        }
        public Permission Update([FromBody] PermissionModel permission)
        {
            var entity = _permissionRepository.FindAll(x => x.PerId == permission.PerId).FirstOrDefault();
            entity.PerId = permission.PerId;
            entity.PerName = permission.PerName;
            _permissionRepository.Update(entity);
            return entity;
        }
    }
}
