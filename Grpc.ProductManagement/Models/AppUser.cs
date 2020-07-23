using Grpc.ProductManagement.SharedCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Entitis
{
    [Table("UserModel")]
     public class AppUser : IdentityUser<Guid>, IDomainEntity
     {
            public string Email { get; set; }
            //public string PhoneNumber { get; set; }
            //  public string PasswordHash { get; set; }
            // public string UserName { get; set; }
            public Guid RoleId { get; set; }
            public string FullName { get; set; }
            public string Avatar { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
     }
}
