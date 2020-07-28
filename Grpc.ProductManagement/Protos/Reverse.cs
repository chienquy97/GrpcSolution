//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Grpc.ProductManagement.Protos
//{
//    public class Reverse
//    {
//        static async Task<string> Reverse()
//        {
//            Channel channel = new Channel("localhost", 11111, ChannelCredentials.Insecure);
//            RevService.Generated.RevService.RevServiceClient client = new RevService.Generated.RevService.RevServiceClient(channel);


//            var data = new RevService.Generated.Data() { Str = "1111" };
//            var res = await client.ReverseAsync(data);
//            return res.Str;
//        }
//    }
//}
