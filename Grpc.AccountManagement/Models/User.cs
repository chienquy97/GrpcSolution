using Grpc.AccountManagement.SharedCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Models
{
    public class User : DomainEntity<int>
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string UserId { get; set; }
    }
}
