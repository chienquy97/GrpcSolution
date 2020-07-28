using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.ProductManagement.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RevService.Generated;
using Channel = Grpc.Core.Channel;

namespace Grpc.ProductManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var reverseString = Reverse().GetAwaiter().GetResult();
            Console.WriteLine(reverseString);
            CreateHostBuilder(args).Build().Run(); 
        }
        static async Task<string> Reverse()
        {
            Channel channel = new Channel("localhost", 11111, ChannelCredentials.Insecure);
            RevService.Generated.RevService.RevServiceClient client = new RevService.Generated.RevService.RevServiceClient(channel);


            var data = new RevService.Generated.Data() { UserId = "aaa", Permissions = "a,b,c" };
            var res = await client.ReverseAsync(data);
            return res.Permissions;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
