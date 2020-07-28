using Grpc.AccountManagement.SharedCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.ViewModels
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public int[] PerIds { get; set; }
    }
    public class RoleCreateViewModel
    {
        public string RoleName { get; set; }
        public int[] PerIds { get; set; }
    }
}
