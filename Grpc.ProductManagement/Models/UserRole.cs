using Grpc.ProductManagement.SharedCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Models
{
    [Table("UserRole")]
    public class UserRole : DomainEntity<int>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
