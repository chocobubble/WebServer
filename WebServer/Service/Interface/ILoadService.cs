using System;
using Grpc.Core;
using WebServer.Protos;

namespace WebServer.Service.Interface
{
    public interface ILoadService
    {
        public string LoadData();
    }

    public class CharacterData
    {
        Int32 Level {  get; set; }
        Int32 Exp { get; set; }
        public string PlayerName { get; set; }
        Int32 Gold { get; set; }
        WeaponSaveData weaponSaveData { get; set; }
        Int32 RifleAmmo {  get; set; }
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

