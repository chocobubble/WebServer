﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using ProtoBuf;

namespace WebServer.Model
{
    [ProtoContract]
    public enum WeaponType
    {
        [EnumMember]
        [ProtoEnum]
        EWT_DEFAULT = 0,
        [EnumMember]
        [ProtoEnum]
        EWT_RIFLE = 1,
        [EnumMember]
        [ProtoEnum]
        EWT_PISTOL = 2,
        [EnumMember]
        [ProtoEnum]
        EWT_SHOTGUN = 3
    }

    [ProtoContract]
    public enum WeaponType2
    {
        [ProtoMember(0)]
        EWT_DEFAULT = 0,
        [ProtoMember(1)]
        EWT_RIFLE = 1,
        [ProtoMember(2)]
        EWT_PISTOL = 2,
        [ProtoMember(3)]
        EWT_SHOTGUN = 3
    }

    [ProtoContract]
    public class CharacterData
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public int exp { get; set; }
        [ProtoMember(3)]
        public string player_name { get; set; }
        [ProtoMember(4)]
        public int gold { get; set; }
        [ProtoMember(5)]
        public List<WeaponData> weapon_data { get; set; }
    }

    [ProtoContract]
    public class WeaponData
    {
        [ProtoMember(1)]
        public int weapon_id { get; set; }
        [ProtoMember(2)]
        public string unique_id { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
        [ProtoMember(4)]
        public int enhancement { get; set; }
    }

    [ProtoContract]
    public class CharacterData2
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
    public class WeaponData2
    {
        [ProtoMember(1)]
        public WeaponType weaponType { get; set; }
        [ProtoMember(2)]
        public int weaponLevel { get; set; }
        [ProtoMember(3)]
        public int weaponEnhancementLevel { get; set; }
    }
}

