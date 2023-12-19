using System;
using ProtoBuf;
namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class CreateAccountRequest : BaseRequest
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }
    }

    [ProtoContract]
    public class CreateAccountResponse : BaseResponse
    {
    }

    [ProtoContract]
    public class CreateAccountRequest2
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }

        [ProtoMember(3)]
        public string sessionId { get; set; }
    }

}

