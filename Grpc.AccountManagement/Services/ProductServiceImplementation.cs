using Grpc.Core;
using RevService.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Services
{
    public class ProductServiceImplementation : RevService.Generated.RevService.RevServiceBase
    {
        public override Task<Data> Reverse(Data request, ServerCallContext context)
        {
            var response = new Data() { Str = new string(request.Str.Reverse().ToArray()) };
            return Task.FromResult(response);
        }
    }
}
