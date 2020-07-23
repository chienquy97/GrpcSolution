using Grpc.AccountManagement.SharedCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Models
{
    [Table("AppRole")]
    public class AppRole : IdentityRole<Guid>
    {
        public int DeleteFlag { get; set; }
    }
}
