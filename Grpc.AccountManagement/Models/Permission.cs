using Grpc.AccountManagement.SharedCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Models
{
    [Table("Permisson")]
    public class Permission : DomainEntity<int>
    {
        public string PerName { get; set; }
    }
}
