using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Grpc.AccountManagement
{
    public interface IUnitOfWork : IDisposable
    {

        int SaveChanges();
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
