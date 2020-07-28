
using AutoMapper;
using Grpc.AccountManagement.Entitis;
using Grpc.AccountManagement.Enums;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.IServices;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Services
{
    public class AppUserService : IAppUserService
    {

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserRepository _appUserRepo;
        private readonly AppDbContext _dbContext;
        public AppUserService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, AppDbContext dbContext, IAppUserRepository appUserRepo, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _appUserRepo = appUserRepo;
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<object> GetById(Guid id)
        {
            try
            {
                List<AppUser> data = await _userManager.Users.ToListAsync();
                var query = from d in data
                            select
                            new
                            {
                                d.Id,
                                d.UserName,
                                d.PasswordHash,
                                d.Email,
                                DateCreated = d.DateCreated.ToShortDateString(),
                                d.FullName,
                                d.PhoneNumber,
                            };
                var result = query.Where(x => x.Id.Equals(id)).FirstOrDefault();
                return result;
                //await _userManager.Users.ProjectTo<AppUserViewModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        
        public async Task<IdentityResult> AddAsync(AppUserlCreateViewMode userVm)
        {
            var user = new AppUser();
            user.FullName = userVm.FullName;
            user.Email = userVm.Email;
            user.PhoneNumber = userVm.PhoneNumber;
            user.UserName = userVm.UserName;
            user.Avatar = userVm.Avatar;
            user.PasswordHash = userVm.PasswordHash;
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;
            var data = await _userManager.CreateAsync(user, userVm.PasswordHash);
            SaveChanges();

            if (!data.Succeeded)
                return data;

            var createdUser = await _userManager.FindByNameAsync(user.UserName);
            foreach (var roleId in userVm.RoleIds)
            {
                _dbContext.UserRole.Add(new UserRole { UserId = createdUser.Id, RoleId = roleId });
            }
            SaveChanges();

            return data;
        }
        public List<AppUser> GetAll()
        {
            var user = _appUserRepo.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).ToList();
            return user;
        }

        public AppUserModel GetByIdd(Guid id)
        {
            var user = _appUserRepo.FindAll(x => x.DeleteFlag != DeleteFlg.Delete).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<AppUser, AppUserModel>(user);

        }
        public async Task<AppUser> Update([FromBody] AppUserModel app)
        {
            var entity = _appUserRepo.FindAll(x => x.Id == app.id).FirstOrDefault();
            entity.UserName = app.UserName;
            entity.PasswordHash = app.PasswordHash;
            entity.FullName = app.FullName;
            entity.Email = app.Email;
            entity.PhoneNumber = app.PhoneNumber;
            entity.Avatar = app.Avatar;
            entity.DateCreated = DateTime.Now;
            //_appUserRepo.Update(entity);
            await _userManager.UpdateAsync(entity);

            //Delete previous roles
            var rolesInDb = _dbContext.UserRole.Where(x => x.UserId == app.id);
            _dbContext.UserRole.RemoveRange(rolesInDb);

            //Update new roles
            foreach (var roleId in app.RoleIds)
            {
                _dbContext.UserRole.Add(new UserRole { UserId = (Guid)app.id, RoleId = roleId });
            }

            SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
           // _appUserRepo.Remove(id);
            SaveChanges();
        }
        private void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
