using System;
using ProtoBuf;

namespace WebServer.Check
{
    [ProtoContract]
    public class LoginRequest : BaseRequest
    {
        [ProtoMember(2)]
        public string Id { get; set; }
        [ProtoMember(3)]
        public string Password { get; set; }
    }

    [ProtoContract]
    public class LoginResponse : BaseResponse
    {
        [ProtoMember(2)]
        public string SessionId { get; set; }
    }

    [ProtoContract]
    public class LoginRequest2
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
        [ProtoMember(2)]
        public string Id { get; set; }
        [ProtoMember(3)]
        public string Password { get; set; }
    }
}

