using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.ViewModels
{
    public class PermissionModel
    {
        public int PerId { get; set; }
        public string PerName { get; set; }
    }
    public class PermissionCreateViewModel
    {
        public string PerName { get; set; }
    }
}
