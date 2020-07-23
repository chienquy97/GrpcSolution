using AutoMapper;
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
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly AppDbContext _dbContext;
        public RoleService(IUnitOfWork unitOfWork, AppDbContext dbContext, IRoleRepository roleRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _dbContext = dbContext;
        }
        #region GET
        public List<AppRole> GetAll()
        {
            var role = _roleRepository.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();
            return role;
        }

        public RoleModel GetById(Guid id)
        {
            var role = _roleRepository.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<AppRole, RoleModel>(role);

        }
        #endregion GET
        #region POST

        #endregion POST
        public bool Add(AppRole appRole)
        {
            _roleRepository.Add(appRole);
            SaveChanges();
            return true;
        }
        //public List<AppRole> Add(List<RoleCreateViewModel> Vm)
        //{
        //    var entity = _mapper.Map<List<AppRole>>(Vm);
        //    _roleRepository.Add(entity);
        //    SaveChanges();

        //    #region Update Images
        //    //var vmFirst = Vm.FirstOrDefault();
        //    //var listHome = _roleRepository.FindAll();
        //    //var firstHome = listHome.FirstOrDefault();

        //    //foreach (var data in listHome)
        //    //{
        //    //    if (!string.IsNullOrEmpty(vmFirst.FirstImgUrl))
        //    //    {
        //    //        data.FirstImgUrl = vmFirst.FirstImgUrl;
        //    //    }
        //    //    else
        //    //    {
        //    //        if (firstHome != null)
        //    //            data.FirstImgUrl = firstHome.FirstImgUrl;
        //    //    }

        //    //    if (!string.IsNullOrEmpty(vmFirst.SencondImgUrl))
        //    //    {
        //    //        data.SencondImgUrl = vmFirst.SencondImgUrl;
        //    //    }
        //    //    else
        //    //    {
        //    //        if (firstHome != null)
        //    //            data.SencondImgUrl = firstHome.SencondImgUrl;
        //    //    }
        //    //    _ihomeRepo.Update(data);
        //    //}
        //    SaveChanges();
        //    #endregion

        //    return entity;
        //}


        public async Task<AppRole> GetAppRoleAsync()
        {
            var result = _roleRepository.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();


            if (result.Count > 0)
            {
                return result[0];
            }
            return null;
        }

        public AppRole Update([FromBody] RoleModel app)
        {
            var entity = _roleRepository.FindAll(x => x.Id == app.id).FirstOrDefault();
            entity.Name = app.RoleName;
            _roleRepository.Update(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            //_roleRepository.Remove(id);
            SaveChanges();
        }
        private void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
