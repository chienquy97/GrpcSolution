using Grpc.AccountManagement.SharedCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Models
{
    [Table("RolePermission")]
    public class RolePermission : DomainEntity<int>
    {
        public Guid RoleId { get; set; }
        public int PerId { get; set; }         
    }
}
