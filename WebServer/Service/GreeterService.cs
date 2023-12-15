using System;
using Grpc.Core;

namespace WebServer.Service.Interface
{
    public class GreeterService : IGreeter
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
        }
    }
}

