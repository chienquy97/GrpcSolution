using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.AccountManagement.Dtos;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.IServices;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grpc.AccountManagement.Context
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        
        private readonly IPermissionService _permissionService;
        private IUnitOfWork _unitOfWork;
        /*private readonly UserManager<Student> _userManager;*/
       
        private readonly IPermissionRepository _permissionRepository;
        //private IHomeRepository _ihomeRepo;
        private readonly AppDbContext _dbContext;

        public PermissionController(IPermissionService permissionServicee, IUnitOfWork unitOfWork,AppDbContext dbContext,IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionService = permissionServicee;
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("Add")]
        // [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        public IActionResult Add([FromBody] Permission permission)
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
                    _permissionService.Add(permission);

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
        public IActionResult Get([FromBody] Permission permission)
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
                    _permissionService.Add(permission);

                    return new OkObjectResult(new GenericResult(true, "Add success!!!"));
                }
                catch (Exception ex)
                {
                    return new OkObjectResult(new GenericResult(false, ex.Message));
                }
            }
        }

        [HttpGet]
        [Route("Pemission")]
        //[AppAuthorize(PermissionTypes.Any, PermissionRule.view_contact)]
        public IActionResult Permission()
        {
            try
            {
                var data = _permissionService.GetPermissionAsync();
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
        public IActionResult Update([FromBody] PermissionModel permission)
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
                    _permissionService.Update(permission);

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
                _permissionService.Delete(id);

                return new OkObjectResult(new GenericResult(true, "Delete success!!!"));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }

        }
    }
}
