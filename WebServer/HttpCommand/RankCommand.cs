using System;
using ProtoBuf;
namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class RankRequest : BaseRequest
    {
    }

    [ProtoContract]
    public class RankResponse : BaseResponse
    {
        [ProtoMember(1)]
        public int ranking { get; set; }
    }
}

