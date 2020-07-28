using Grpc.AccountManagement.SharedCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.ViewModels
{
    public class PermissionModel : DomainEntity<int>
    {
        public string PerName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int DeleteFlag { get; set; }
    }
    public class PermissionCreateViewModel
    {
        public string PerName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int DeleteFlag { get; set; }
    }
}
