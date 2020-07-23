using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement.Authorization
{
    public static class PermissionRule
    {
        public const string view_home = nameof(view_home);
        public const string update_home = nameof(update_home);
        public const string view_introduction = nameof(view_introduction);
        public const string update_introduction = nameof(update_introduction);
        public const string view_ground = nameof(view_ground);
        public const string update_ground = nameof(update_ground);
        public const string view_management = nameof(view_management);
        public const string update_management = nameof(update_management);
        public const string view_production = nameof(view_production);
        public const string update_production = nameof(update_production);
        public const string view_library = nameof(view_library);
        public const string update_library = nameof(update_library);
        public const string view_news = nameof(view_news);
        public const string update_news = nameof(update_news);
        public const string view_contact = nameof(view_contact);
        public const string update_contact = nameof(update_contact);
        public const string view_register = nameof(view_register);
        public const string view_user = nameof(view_user);
        public const string update_user = nameof(update_user);
        public const string view_role = nameof(view_role);
        public const string update_role = nameof(update_role);
    }
}
