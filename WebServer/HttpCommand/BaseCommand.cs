using System;
using ProtoBuf;
namespace WebServer.HttpCommand
{
	[ProtoContract]
    [ProtoInclude(2, typeof(CreateAccountRequest))]
    [ProtoInclude(3, typeof(CharacterDataLoadRequest))]
    [ProtoInclude(4, typeof(CharacterDataSaveRequest))]
    [ProtoInclude(5, typeof(LoginRequest))]
    [ProtoInclude(6, typeof(LogoutRequest))]
    [ProtoInclude(7, typeof(RefreshSessionRequest))]
    public class BaseRequest
	{
		[ProtoMember(1)]
		public string sessionId { get; set; }
	}

	[ProtoContract]
    [ProtoInclude(2, typeof(CreateAccountResponse))]
    [ProtoInclude(3, typeof(CharacterDataLoadResponse))]
    [ProtoInclude(4, typeof(CharacterDataSaveResponse))]
    [ProtoInclude(5, typeof(LoginResponse))]
    [ProtoInclude(6, typeof(LogoutResponse))]
    [ProtoInclude(7, typeof(RefreshSessionResponse))]
    public class BaseResponse
	{
		[ProtoMember(1)]
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

