
using Grpc.AccountManagement.Entitis;
using Grpc.AccountManagement.IRepositories;
using Grpc.AccountManagement.Models;
namespace Grpc.AccountManagement.Repositories
{
    public class AppUserRepository : EFRepository<AppUser>, IAppUserRepository
    {
        private AppDbContext _appContext;
        public AppUserRepository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }
    }
}
