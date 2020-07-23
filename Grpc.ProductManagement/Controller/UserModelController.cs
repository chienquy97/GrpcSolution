using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Grpc.ProductManagement.Authorization;
using Grpc.ProductManagement.Dtos;
using Grpc.ProductManagement.Entitis;
using Grpc.ProductManagement.IServices;
using Grpc.ProductManagement.Services;
using Grpc.ProductManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Grpc.ProductManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        
        //private readonly UserModelService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _appConfiguration;
        private IAppUserService _userModelService;
        

        private readonly ILogger<PermissionController> _logger;

        public PermissionController(ILogger<PermissionController> logger,AppUserService userService,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IConfiguration appConfiguration,IAppUserService userModelService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appConfiguration = appConfiguration;
            _logger = logger;
            _userModelService = userModelService;
        }
      
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
                    IdentityResult data = await _userModelService.AddAsync(Vm);
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
    }
}

