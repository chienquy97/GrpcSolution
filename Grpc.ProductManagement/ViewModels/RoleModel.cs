using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.ViewModels
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class RoleCreateViewModel
    {
        public string RoleName { get; set; }
    }
}
