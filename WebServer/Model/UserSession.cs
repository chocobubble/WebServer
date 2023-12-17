using System;
using ProtoBuf;

namespace WebServer.Model
{
    [ProtoContract]
	public class UserSession
	{
        [ProtoMember(1)]
        public string SessionId { get; set; }
        [ProtoMember(2)]
        public string UserId { get; set; }
        [ProtoMember(3)]
        public DateTime ExpireTime { get; set; }
        [ProtoMember(4)]
        public string State { get; set; }
    }
}

