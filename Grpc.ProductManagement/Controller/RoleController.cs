using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.ProductManagement.Context;
using Grpc.ProductManagement.Dtos;
using Grpc.ProductManagement.IRepositories;
using Grpc.ProductManagement.IServices;
using Grpc.ProductManagement.Models;
using Grpc.ProductManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Grpc.ProductManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _iroleService;
        private IUnitOfWork _unitOfWork;
        /*private readonly UserManager<Student> _userManager;*/
        private readonly IRoleRepository _iroleRepository;
        //private IHomeRepository _ihomeRepo;
        private readonly AppDbContext _dbContext;

        public RoleController(IRoleService iroleService, IUnitOfWork unitOfWork, AppDbContext dbContext, IRoleRepository iroleRepository)
        {
            _iroleService = iroleService;
            _iroleRepository = iroleRepository;
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("Add")]
        // [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        public IActionResult Add([FromBody] Role role)
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
                    _iroleService.Add(role);

                    return new OkObjectResult(new GenericResult(true, "Add success!!!"));
                }
                catch (Exception ex)
                {
                    return new OkObjectResult(new GenericResult(false, ex.Message));
                }
            }
        }


        [HttpPost]
        [Route("Get")]
        // [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        public IActionResult Get([FromBody] Role role)
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
                    _iroleService.Add(role);

                    return new OkObjectResult(new GenericResult(true, "Add success!!!"));
                }
                catch (Exception ex)
                {
                    return new OkObjectResult(new GenericResult(false, ex.Message));
                }
            }
        }

        [HttpGet]
        [Route("Role")]
        //[AppAuthorize(PermissionTypes.Any, PermissionRule.view_contact)]
        public IActionResult Role()
        {
            try
            {
                var data = _iroleService.GetAppRoleAsync();
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
        public IActionResult Update([FromBody] RoleModel roleModel)
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
                    _iroleService.Update(roleModel);

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
                _iroleService.Delete(id);

                return new OkObjectResult(new GenericResult(true, "Delete success!!!"));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }

        }
    }
}
