using System;
using ProtoBuf;
namespace WebServer.Check
{
	[ProtoContract]
	public class BaseRequest
	{
		[ProtoMember(1)]
		public string sessionId { get; set; }
	}

	[ProtoContract]
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

