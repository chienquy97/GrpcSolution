using Grpc.ProductManagement.Entitis;
using Grpc.ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Grpc.ProductManagement.IRepositories
{
    public interface IAppUserRepository : IRepository<AppUser,int>
    {
    }
}
