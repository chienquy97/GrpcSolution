using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.ViewModels
{
    public class AppUserModel
    {
        public Guid? Id { set; get; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public Guid RoleId { get; set; }
    }
    public class AppUserCreateViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDay { set; get; }
        public string Avatar { get; set; }
        public string PasswordHash { get; set; }
        public Guid RoleId { get; set; }
    }
}
