using Grpc.ProductManagement.SharedCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Models
{
    [Table("Role")]
    public class Role : DomainEntity<int>
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
