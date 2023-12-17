using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using ProtoBuf;

namespace WebServer.Model
{
    public enum WeaponType
    {
        EWT_RIFLE = 0,
        EWT_PISTOL = 1,
        EWT_SHOTGUN = 2
    }

    [ProtoContract]
    public class CharacterData2
    {
        [ProtoMember(1)]
        public Int32 Level { get; set; }
        [ProtoMember(2)]
        public Int32 Exp { get; set; }
        [ProtoMember(3)]
        public string PlayerName { get; set; }
        [ProtoMember(4)]
        public Int32 Gold { get; set; }
        [ProtoMember(5)]
        public WeaponSaveData2 weaponSaveData { get; set; }
        [ProtoMember(6)]
        public Int32 RifleAmmo { get; set; }
    }

    [ProtoContract]
    public class WeaponSaveData2
    {
        [ProtoMember(1)]
        public WeaponType weaponType { get; set; }
        [ProtoMember(2)]
        public Int32 WeaponLevel { get; set; }
        [ProtoMember(3)]
        public Int32 WeaponEnhancementLevel { get; set; }
    }
}

