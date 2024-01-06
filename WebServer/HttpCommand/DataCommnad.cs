using System;
using ProtoBuf;
using WebServer.Model;

namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class CharacterDataLoadRequest2
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
    }

    [ProtoContract]
    public class CharacterDataLoadResponse2
    {
        [ProtoMember(2)]
        public ApiReturnCode apiReturnCode { get; set; }
        [ProtoMember(1)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveRequest2
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
        [ProtoMember(2)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveResponse2
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
    }

    [ProtoContract]
    public class CharacterDataLoadRequest : BaseRequest
    {
    }

    [ProtoContract]
    public class CharacterDataLoadResponse : BaseResponse
    {
        [ProtoMember(1)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveRequest : BaseRequest
    {
        [ProtoMember(1)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveResponse : BaseResponse
    {
    }
}
    

