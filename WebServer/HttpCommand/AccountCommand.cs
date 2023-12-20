using System;
using ProtoBuf;
namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class CreateAccountRequest
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
        [ProtoMember(2)]
        public string id { get; set; }
        [ProtoMember(3)]
        public string password { get; set; }

    }

    [ProtoContract]
    public class CreateAccountResponse
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
    }

    [ProtoContract]
    public class CreateAccountRequest2 : BaseRequest
    {
        [ProtoMember(2)]
        public string id { get; set; }
        [ProtoMember(3)]
        public string password { get; set; }
    }

    [ProtoContract]
    public class CreateAccountResponse2 : BaseResponse
    {
    }
}

