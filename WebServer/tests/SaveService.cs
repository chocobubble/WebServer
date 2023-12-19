using WebServer.Protos;
using WebServer.Repository;
using WebServer.Repository.Interface;
using WebServer.Service.Interface;

namespace WebServer.Test
{
    /*
    public class SaveService : ISaveService
    {
        private IAccountRepository _accountRepository;

        public SaveService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public string SaveData(string userId, CharacterData from)
        {
            CharacterData to = _accountRepository.GetUserCharacterData(userId);
            to.Level = from.Level;
            to.Exp = from.Exp;
            to.PlayerName = from.PlayerName;
            to.Gold = from.Gold;
            to.WeaponSaveData.WeaponLevel = from.WeaponSaveData.WeaponLevel;
            to.WeaponSaveData.WeaponEnhancementLevel = from.WeaponSaveData.WeaponEnhancementLevel;
            to.WeaponSaveData.WeaponType = from.WeaponSaveData.WeaponType;
            to.RifleAmmo = from.RifleAmmo;
            return "Save complete";
        }

        public string SaveData(string userId, byte[] bytes)
        {
            CharacterData from = CharacterData.Parser.ParseFrom(bytes);
            CharacterData to = _accountRepository.GetUserCharacterData(userId);
            to.Level = from.Level;
            to.Exp = from.Exp;
            to.PlayerName = from.PlayerName;
            to.Gold = from.Gold;
            to.WeaponSaveData = new WeaponSaveData();
            if (from.WeaponSaveData != null)
            { 
                to.WeaponSaveData.WeaponLevel = from.WeaponSaveData.WeaponLevel;
                to.WeaponSaveData.WeaponEnhancementLevel = from.WeaponSaveData.WeaponEnhancementLevel;
                to.WeaponSaveData.WeaponType = from.WeaponSaveData.WeaponType;
            }
            to.RifleAmmo = from.RifleAmmo;
            return "Save complete";
        }

    }
    */
}
