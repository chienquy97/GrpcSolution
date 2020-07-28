using Grpc.AccountManagement.SharedCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Models
{
    [Table("Permisson")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string PerName { get; set; }
        public int DeleteFlag { get; set; }
        
    }
}
