using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Grpc.AccountManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Grpc.AccountManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
      //  [HttpGet]
    //    public IActionResult Login(string username, string pass)
    //    {
    //        User login = new User();
    //        login.UserName = username;
    //        login.PassWord = pass;
    //        IActionResult response = Unauthorized();

    //        var user = AuthenticateUser(login);
    //        if (user != null)
    //        {
    //            var tokenStr = GenerateJSONWebToken(user);
    //            response = Ok(new { token = tokenStr });
    //        }
    //        return response;
    //    }

    //    [HttpPost]
    //    [Route("DecodeJwt")]
    //    public IActionResult DecodeJwt(Jwt jwt)
    //    {
    //        var result = jwt.Content;

    //        string secret = "ChienQuySecretKey";
    //        var key = Encoding.ASCII.GetBytes(secret);
    //        var handler = new JwtSecurityTokenHandler();
    //        var validations = new TokenValidationParameters
    //        {
    //            ValidateIssuerSigningKey = true,
    //            IssuerSigningKey = new SymmetricSecurityKey(key),
    //            ValidateIssuer = false,
    //            ValidateAudience = false
    //        };
    //        var claims = handler.ValidateToken(result, validations, out var tokenSecure);
    //        var a = claims.Claims.ToList()[3].Value;
    //        //var b = a?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;

    //        return Ok(new { result });
    //    }
    //    private User AuthenticateUser(User login)
    //    {
    //        User user = null;
    //        if (login.UserName == "chienquy" && login.PassWord == "123")
    //        {
    //            user = new User { UserName = "ChienQuy", UserId = "chienquy@gmail.com", PassWord = "123" };
    //        }
    //        return user;
    //    }
    //    private string GenerateJSONWebToken(User userinfo)
    //    {
    //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    //        var claims = new[]
    //        {
    //            new Claim(JwtRegisteredClaimNames.Sub,userinfo.UserName),
    //            new Claim(JwtRegisteredClaimNames.Email,userinfo.UserId),
    //            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
    //            new Claim("UserId", "chien@gmail.com")
    //            //new Claim(ClaimTypes.Role,userinfo.RoleName)
    //        };
    //        var token = new JwtSecurityToken(
    //            issuer: _config["Jwt:Issuer"],
    //            audience: _config["Jwt:Issuer"],
    //            claims,
    //            expires: DateTime.UtcNow.AddMinutes(90),
    //            signingCredentials: credentials);
    //        var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
    //        return encodetoken;
    //    }
    //    [HttpPost("Post")]
    //    [Authorize]
    //    public string Post()
    //    {
    //        var identity = HttpContext.User.Identity as ClaimsIdentity;
    //        IList<Claim> claim = identity.Claims.ToList();
    //        var userName = claim[0].Value;
    //        return "Welcome  to " + userName;
    //    }
    //    [Authorize(Roles = "Administrator")]
    //    [HttpGet("GetValue")]
    //    public ActionResult<IEnumerable<string>> Get()
    //    {
    //        return new string[] { "Value1", "Value2", "Value3" };
    //    }
    //}

    //public class Jwt
    //{
    //    public string Content { get; set; }
    }
}
