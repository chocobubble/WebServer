using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using ProtoBuf;

namespace WebServer.Model
{
    [ProtoContract]
    public enum WeaponType
    {
        [ProtoEnum]
        EWT_DEFAULT = 0,
        [ProtoEnum]
        EWT_RIFLE = 1,
        [ProtoEnum]
        EWT_PISTOL = 2,
        [ProtoEnum]
        EWT_SHOTGUN = 3
    }

    [ProtoContract]
    public class CharacterSaveData
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public int exp { get; set; }
        [ProtoMember(3)]
        public string playerName { get; set; }
        [ProtoMember(4)]
        public int gold { get; set; }
        [ProtoMember(5)]
        public WeaponData weaponData { get; set; }
        [ProtoMember(6)]
        public int rifleAmmo { get; set; }
    }

    [ProtoContract]
    public class WeaponData
    {
        [ProtoMember(1)]
        public WeaponType weaponType { get; set; }
        [ProtoMember(2)]
        public int weaponLevel { get; set; }
        [ProtoMember(3)]
        public int weaponEnhancementLevel { get; set; }
    }
}

