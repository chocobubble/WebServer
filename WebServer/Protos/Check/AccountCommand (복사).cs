using System;
using ProtoBuf;
namespace WebServer.Check
{
    [ProtoContract]
    public class CreateAccountRequest : BaseRequest
    {
        [ProtoMember(2)]
        public string id { get; set; }
        [ProtoMember(3)]
        public string password { get; set; }
    }

    [ProtoContract]
    public class CreateAccountRequest2
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
        [ProtoMember(2)]
        public string id { get; set; }
        [ProtoMember(3)]
        public string password { get; set; }

    }

}

