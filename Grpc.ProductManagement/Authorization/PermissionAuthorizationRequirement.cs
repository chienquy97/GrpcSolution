using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Grpc.ProductManagement.Authorization
{
    public class PermissionAuthorizationRequirement
    {
        public string[] Permissions { get; private set; }

        public PermissionAuthorizationRequirement(string[] permissions)
        {
            Permissions = permissions;
        }
    }
}
