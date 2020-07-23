using Grpc.ProductManagement.SharedCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Models
{
    [Table("Permission")]
    public class Permission : DomainEntity<int>
    {
        public int PerId { get; set; }
        public string PerName { get; set; }
    }
}
