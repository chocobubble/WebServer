using System;
using ProtoBuf;
using WebServer.Model;

namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class CharacterDataLoadRequest
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
    }

    [ProtoContract]
    public class CharacterDataLoadResponse
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
        [ProtoMember(2)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveRequest
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
        [ProtoMember(2)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveResponse
    {
        [ProtoMember(1)]
        public ApiReturnCode apiReturnCode { get; set; }
    }

    [ProtoContract]
    public class CharacterDataLoadRequest2 : BaseRequest
    {
    }

    [ProtoContract]
    public class CharacterDataLoadResponse2 : BaseResponse
    {
        [ProtoMember(2)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveRequest2 : BaseRequest
    {
        [ProtoMember(2)]
        public CharacterData characterData { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveResponse2 : BaseResponse
    {
        [ProtoMember(1)]
        public string sessionId { get; set; }
    }
}
    

