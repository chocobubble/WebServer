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
        public ApiReturnCode ApiReturnCode { get; set; }
    }

    [ProtoContract]
    public enum ApiReturnCode
    {
		[ProtoMember(1)]
        Success = 1,
		[ProtoMember(2)]
        UnknownSessionId = 2,
    }
}

