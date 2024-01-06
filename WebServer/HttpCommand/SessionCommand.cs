using System;
using ProtoBuf;

namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class LoginRequest2
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
        [ProtoMember(2)]
        public string id { get; set; }
        [ProtoMember(3)]
        public string password { get; set; }
    }

    [ProtoContract]
    public class LoginResponse2
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
        [ProtoMember(2)]
        public string sessionId { get; set; }
    }

    [ProtoContract]
    public class LogoutRequest2
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
    }

    [ProtoContract]
    public class LogoutResponse2
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
    }


    [ProtoContract]
    public class LoginRequest : BaseRequest
    {
        [ProtoMember(1)]
        public string id { get; set; }
        [ProtoMember(2)]
        public string password { get; set; }
    }

    [ProtoContract]
    public class LoginResponse : BaseResponse
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
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

