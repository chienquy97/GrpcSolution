using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Grpc.AccountManagement.Dtos;
using Grpc.AccountManagement.Entitis;
using Grpc.AccountManagement.IServices;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.Services;
using Grpc.AccountManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Grpc.AccountManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        //private readonly AppUserService _appuserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _appConfiguration;
        private IAppUserService _appUserService;
      //  private readonly ILogger<AppUserController> _logger;

        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration appConfiguration, IAppUserService appUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appConfiguration = appConfiguration;
            _appUserService = appUserService;
        }
        #region POST


        #endregion POST
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(model);
            }
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
                if (result.IsLockedOut)
                {
                    return new ObjectResult(new GenericResult(false, "Login failed!"));
                }
                else if (!result.Succeeded)
                {
                    //return new BadRequestObjectResult(result.ToString());
                    return new ObjectResult(new GenericResult(false, "Login failed!"));
                }

                //var x = await _userService.GetById(user.Id);
                //var listRole = x.listRole;

                //var data = new List<string>();
                //foreach (var item in listRole)
                //{
                //    data.Add(item.Name);
                //}

                var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim("roles", "RoleName"),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_appConfiguration["Tokens:Issuer"],
                    _appConfiguration["Tokens:Issuer"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds);

                var token_access = new JwtSecurityTokenHandler().WriteToken(token);

                return new ObjectResult(new GenericResult(true, token_access));


            }

            return new ObjectResult(new GenericResult(false, "Login failed!"));
        }

        [HttpPost]
        [Route("Add")]
        //[AppAuthorize(PermissionTypes.Any, PermissionRule.update_user)]
        public async Task<IActionResult> Add([FromBody] AppUserModel Vm)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(new GenericResult(false, allErrors));
            }
            else
            {
                try
                {
                    IdentityResult data = await _appUserService.AddAsync(Vm);
                    if (data.Succeeded)
                    {
                        return new OkObjectResult(new GenericResult(true));
                    }
                    else
                    {
                        return new OkObjectResult(new GenericResult(false, data.Errors));
                    }
                }
                catch (Exception ex)
                {
                    return new OkObjectResult(new GenericResult(false, ex.Message));
                }
            }
        }
        [HttpGet]
        [Route("GetAll")]
        //[AppAuthorize(PermissionTypes.Any, PermissionRule.view_contact)]
        public IActionResult GetAll()
        {
            try
            {
                var role = _appUserService.GetAll();
                return new OkObjectResult(new GenericResult(true, role));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }
        [HttpGet]
        [Route("GetByIdd")]
        //[AppAuthorize(PermissionTypes.Any, PermissionRule.view_contact)]
        public IActionResult GetByIdd(Guid id)
        {
            try
            {
                var data = _appUserService.GetByIdd(id);
                return new OkObjectResult(new GenericResult(true, data));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }
        [HttpPut]
        [Route("Update")]
        // [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        public IActionResult Update([FromBody] AppUserModel appUser)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(new GenericResult(false, allErrors));
            }
            else
            {
                try
                {
                    _appUserService.Update(appUser);

                    return new OkObjectResult(new GenericResult(true, "Update success!!!"));
                }
                catch (Exception ex)
                {
                    return new OkObjectResult(new GenericResult(false, ex.Message));
                }
            }
        }


        [HttpDelete]
        [Route("Delete")]
        // [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        public IActionResult Delete(int id)
        {
            try
            {
                _appUserService.Delete(id);

                return new OkObjectResult(new GenericResult(true, "Delete success!!!"));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }

        }
    }
}
