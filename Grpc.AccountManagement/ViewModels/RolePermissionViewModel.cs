using Grpc.AccountManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.ViewModels
{
    public class RolePermissionViewModel
    {
        public Guid RoleId { get; set; }
        public int[] PerIds { get; set; }
    }
    public class Pe
    {
        public int PerIds { get; set; }
    }
}
