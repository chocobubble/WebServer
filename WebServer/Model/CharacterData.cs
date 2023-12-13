using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WebServer.Model
{
    public class ChaaracterData
    {
        public Int32 Level { get; set; }
        public Int32 Exp { get; set; }
        public string PlayerName { get; set; }
        public Int32 Gold { get; set; }
        public WeaponSaveData weaponSaveData { get; set; }
        public Int32 RifleAmmo { get; set; }
    }

    public class WeaponSaveData
    {
        enum WeaponType
        {
            EWT_RIFLE = 0,
            EWT_PISTOL = 1,
            EWT_SHOTGUN = 2
        }

        Int32 WeaponLevel { get; set; }
        Int32 WeaponEnhancementLevel { get; set; }
    }
}

