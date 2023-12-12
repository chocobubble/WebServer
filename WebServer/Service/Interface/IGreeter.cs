using System;
using Grpc.Core;

namespace WebServer.Service.Interface
{
    public abstract partial class IGreeter
    {
        public virtual Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            throw new RpcException(new Status(StatusCode.Unimplemented, ""));
        }
    }

    public class HelloRequest
    {
        public string Name { get; set; }
    }

    public class HelloReply
    {
        public string Message { get; set; }
    }
}

