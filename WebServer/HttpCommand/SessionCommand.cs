using System;
using ProtoBuf;

namespace WebServer.HttpCommand
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
    public class LogoutRequest : BaseRequest
    {
    }

    [ProtoContract]
    public class LogoutResponse : BaseResponse
    {
    }

    [ProtoContract]
    public class RefreshSessionRequest : BaseRequest
    {
    }

    [ProtoContract]
    public class RefreshSessionResponse : BaseResponse
    {
    }
}

