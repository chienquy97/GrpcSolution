using Grpc.ProductManagement.Context;
using Grpc.ProductManagement.Entitis;
using Grpc.ProductManagement.IRepositories;
using Grpc.ProductManagement.IServices;
using Grpc.ProductManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Services
{
    public class AppUserService : IAppUserService
    {
        
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        /*private readonly UserManager<Student> _userManager;*/
        //private readonly IMapper _mapper;
      //  private readonly IAppUserRepository _userModelRepository;
        //private IHomeRepository _ihomeRepo;
        private readonly AppDbContext _dbContext;
        public AppUserService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, AppDbContext dbContext)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;

        //    _userModelRepository = userModelRepository;
            _dbContext = dbContext;

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
        public async Task<IdentityResult> AddAsync(AppUserModel userVm)
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

            //if (data.Succeeded)
            //{
            //    user.Id = user.Id;
            //    var entity = new UserRole();
            //    entity.UserId = user.Id;
            //    entity.RoleId = userVm.RoleId;
            //    _iUserRoleRepo.Add(entity);
            //    SaveChanges();
            //}
            return data;
        }

        internal void Add(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
