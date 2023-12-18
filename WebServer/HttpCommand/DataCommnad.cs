using System;
using ProtoBuf;
using WebServer.Model;

namespace WebServer.HttpCommand
{
    [ProtoContract]
    public class CharacterDataLoadRequest : BaseRequest
    {
    }

    [ProtoContract]
    public class CharacterDataLoadResponse : BaseResponse
    {
        [ProtoMember(2)]
        CharacterData data { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveRequest : BaseRequest
    {
        [ProtoMember(2)]
        CharacterData data { get; set; }
    }

    [ProtoContract]
    public class CharacterDataSaveResponse : BaseResponse
    {
    }
}

