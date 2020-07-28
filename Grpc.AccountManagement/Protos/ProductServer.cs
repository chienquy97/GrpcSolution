using Grpc.AccountManagement.Services;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.AccountManagement.Protos
{
    public class ProductServer
    {
        private readonly Server _server;
        public ProductServer()
        {
            _server = new Server()
            {
                Services = { RevService.Generated.RevService.BindService(new ProductServiceImplementation()) },
                Ports = { new ServerPort("localhost", 11111, ServerCredentials.Insecure) }
            };
        }
        public void Start()
        {
            _server.Start();
        }
        public async Task ShutDownAsync()
        {
            await _server.ShutdownAsync();
        }
    }
}
