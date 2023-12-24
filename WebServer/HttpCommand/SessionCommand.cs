using System;
using ProtoBuf;

namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class LoginRequest
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
        [ProtoMember(2)]
        public string id { get; set; }
        [ProtoMember(3)]
        public string password { get; set; }
    }

    [ProtoContract]
    public class LoginResponse
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
        [ProtoMember(2)]
        public string sessionId { get; set; }
    }

    [ProtoContract]
    public class LogoutRequest
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
    }

    [ProtoContract]
    public class LogoutResponse
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
    }

    [ProtoContract]
    public class RefreshSessionRequest
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
    }

    [ProtoContract]
    public class RefreshSessionResponse
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
    }


    [ProtoContract]
    public class LoginRequest2 : BaseRequest
    {
        [ProtoMember(2)]
        public string Id { get; set; }
        [ProtoMember(3)]
        public string Password { get; set; }
    }

    [ProtoContract]
    public class LoginResponse2 : BaseResponse
    {
        [ProtoMember(2)]
        public string SessionId { get; set; }
    }

    [ProtoContract]
    public class LogoutRequest2 : BaseRequest
    {
    }

    [ProtoContract]
    public class LogoutResponse2 : BaseResponse
    {
    }

    [ProtoContract]
    public class RefreshSessionRequest2 : BaseRequest
    {
    }

    [ProtoContract]
    public class RefreshSessionResponse2 : BaseResponse
    {
    }
}

