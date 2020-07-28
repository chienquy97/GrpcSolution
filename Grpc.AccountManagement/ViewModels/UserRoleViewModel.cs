using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.ViewModels
{
    public class UserRoleViewModel
    {
        public Guid UserId { get; set; }
        public List<Role> RoleIds { get; set; }
    }
    public class Role 
    { 
        public Guid RoleId { get; set; } 
    }

}
