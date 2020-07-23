using Grpc.AccountManagement.Context;
using Grpc.AccountManagement.Enums;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.IServices;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Services
{
    public class PermissionService : IPermissionService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IPermissionRepository _permissionRepository;
        private readonly AppDbContext _dbContext;
        public PermissionService(IUnitOfWork unitOfWork, AppDbContext dbContext, IPermissionRepository permissionRepository)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = permissionRepository;
            _dbContext = dbContext;

        }
        public bool Add(Permission student)
        {
            _permissionRepository.Add(student);
            SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            //_permissionRepository.Remove(id);
            SaveChanges();
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
        private void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
        public Permission Update(PermissionModel vm)
        {
            var entity = _permissionRepository.FindAll(x => x.Id == vm.Id).FirstOrDefault();
            entity.PerName = vm.PerName;
           
            _permissionRepository.Update(entity);
            SaveChanges();
            return entity;
        }
    }
}
