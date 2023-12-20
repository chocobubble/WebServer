using System;
using ProtoBuf;
namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class RankRequest
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }

    }

    [ProtoContract]
    public class RankResponse
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
        [ProtoMember(2)]
        public int ranking { get; set; }
    }
}

