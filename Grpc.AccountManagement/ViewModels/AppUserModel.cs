using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.ViewModels
{
    public class AppUserModel
    {
        public Guid? id { set; get; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public int DeleteFlag { get; set; }
    }
    public class AppUserlCreateViewMode
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDay { set; get; }
        public string Avatar { get; set; }
        public string PasswordHash { get; set; }
        public int DeleteFlag { get; set; }
    }
}
