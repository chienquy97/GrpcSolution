using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.AccountManagement;
using Grpc.AccountManagement.Dtos;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.IServices;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
using Grpc.AccountManagement.Context;
using Grpc.AccountManagement.Dtos;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.IServices;
using Grpc.AccountManagement.Models;
using Grpc.AccountManagement.ViewModels;
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
        public RoleController(IRoleService iroleService)
        {
            _iroleService = iroleService;
        }

        [HttpGet]
        [Route("GetAll")]
        //[AppAuthorize(PermissionTypes.Any, PermissionRule.view_contact)]
        public IActionResult GetAll()
        {
            try
            {
                var role = _iroleService.GetAll();
                return new OkObjectResult(new GenericResult(true, role));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }

        [HttpGet]
        [Route("GetById")]
        //[AppAuthorize(PermissionTypes.Any, PermissionRule.view_contact)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _iroleService.GetById(id);
                return new OkObjectResult(new GenericResult(true, data));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }


        [HttpPost]
        [Route("Add")]
        // [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        public IActionResult Add([FromBody] AppRole role)
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
        //[HttpPost]
        //[Route("Add")]
        //// [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        //public IActionResult Add([FromBody] List<RoleCreateViewModel> Vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return new BadRequestObjectResult(new GenericResult(false, allErrors));
        //    }
        //    else
        //    {
        //        try
        //        {
        //            _iroleService.Add();

        //            return new OkObjectResult(new GenericResult(true, "Add success!!!"));
        //        }
        //        catch (Exception ex)
        //        {
        //            return new OkObjectResult(new GenericResult(false, ex.Message));
        //        }
        //    }
        //}


        //[HttpPost]
        //[Route("Get")]
        //// [AppAuthorize(PermissionTypes.Any, PermissionRule.update_news)]
        //public IActionResult Get([FromBody] AppRole role)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return new BadRequestObjectResult(new GenericResult(false, allErrors));
        //    }
        //    else
        //    {
        //        try
        //        {
        //            _iroleService.Add(role);

        //            return new OkObjectResult(new GenericResult(true, "Add success!!!"));
        //        }
        //        catch (Exception ex)
        //        {
        //            return new OkObjectResult(new GenericResult(false, ex.Message));
        //        }
        //    }
        //}

        //[HttpGet]
        //[Route("Role")]
        ////[AppAuthorize(PermissionTypes.Any, PermissionRule.view_contact)]
        //public IActionResult Role()
        //{
        //    try
        //    {
        //        var data = _iroleService.GetAppRoleAsync();
        //        return new OkObjectResult(new GenericResult(true, data));
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OkObjectResult(new GenericResult(false, ex.Message));
        //    }
        //}

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
