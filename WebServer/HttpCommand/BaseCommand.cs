using System;
using ProtoBuf;
namespace WebServer.HttpCommand
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
        UnknownSessionId = 2,
        [ProtoMember(3)]
        InvalidUserId = 3,
        [ProtoMember(4)]
        InvalidUserPassword = 4,
    }
}

