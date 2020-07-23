using Grpc.ProductManagement.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.ProductManagement
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _context;
        public EFUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
