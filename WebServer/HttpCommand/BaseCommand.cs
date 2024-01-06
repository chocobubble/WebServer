using System;
using System.Runtime.Serialization;
using ProtoBuf;
namespace WebServer.HttpCommand
{
	[ProtoContract]
    [ProtoInclude(12, typeof(CreateAccountRequest))]
    [ProtoInclude(13, typeof(CharacterDataLoadRequest))]
    [ProtoInclude(14, typeof(CharacterDataSaveRequest))]
    [ProtoInclude(15, typeof(LoginRequest))]
    [ProtoInclude(16, typeof(LogoutRequest))]
    [ProtoInclude(17, typeof(RefreshSessionRequest))]
    public class BaseRequest
	{
		[ProtoMember(1)]
		public string sessionId { get; set; }
	}

	[ProtoContract]
    [ProtoInclude(2, typeof(CharacterDataLoadResponse2))]
    public class BaseResponse
	{
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
    }

    [ProtoContract]
    [ProtoInclude(22, typeof(CreateAccountResponse))]
    [ProtoInclude(23, typeof(CharacterDataLoadResponse))]
    [ProtoInclude(24, typeof(CharacterDataSaveResponse))]
    [ProtoInclude(25, typeof(LoginResponse))]
    [ProtoInclude(26, typeof(LogoutResponse))]
    [ProtoInclude(27, typeof(RefreshSessionResponse))]
    public class BaseResponse2
    {
        [ProtoMember(2)]
        public ApiReturnCode apiReturnCode { get; set; }
    }

    [ProtoContract]
    public enum ApiReturnCode
    {
        None = 0,
        [ProtoMember(1)]
        Success = 1,
        [ProtoMember(2)]
        Fail = 2,
        [ProtoMember(3)]
        InvalidSessionId = 3,
        [ProtoMember(4)]
        InvalidUserId = 4,
        [ProtoMember(5)]
        InvalidUserPassword = 5,
        [ProtoMember(6)]
        DuplicatedLogin = 6,
    }
}

