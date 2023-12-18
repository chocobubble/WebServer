using System;
using ProtoBuf;
namespace WebServer.Check
{
    [ProtoContract]
    public class CreateAccountRequest : BaseRequest
    {
        [ProtoMember(2)]
        public string Id { get; set; }
        [ProtoMember(3)]
        public string Password { get; set; }
    }

    [ProtoContract]
    public class CreateAccountResponse : BaseResponse
    {
    }
}

