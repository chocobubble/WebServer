using System;
using WebServer.Controllers;
using WebServer.Model;
using WebServer.Repository;
using WebServer.Service.Interface;

namespace WebServer.Service
{
    public class SqlService : ISqlService
    {
        private ILogger<SqlService> _logger;
        private AccountDbContext _dbContext;

        public SqlService(ILogger<SqlService> logger, AccountDbContext accountDbContext)
        {
            _logger = logger;
            _dbContext = accountDbContext;
        }

        public bool CreateAccount(string inputId, string inputPwd)
        {
            int emptyId = _dbContext.Account.Count() + 1;
            AccountDataEntity newAccount = new AccountDataEntity(emptyId, inputId, inputPwd);
            _dbContext.Account.Add(newAccount);
            _dbContext.SaveChanges();

            if (emptyId != _dbContext.Account.Count())
            {
                return false;
            }

            return true;
        }

        public bool IsValidId(string inputId)
        {
            if (_dbContext.Account.Any(account => account.UserId == inputId))
            {
                return true;
            }
            return false;
        }

        public bool IsValidPassword(string inputId, string inputPwd)
        {
            AccountDataEntity accountData = _dbContext.Account.SingleOrDefault(account => account.UserId == inputId && account.UserPassword == inputPwd);
            if (accountData == null)
            {
                return false;
            }
            return true;
        }

        public int GetAccountId(string userId)
        {
            AccountDataEntity accountData = _dbContext.Account.SingleOrDefault(account => account.UserId == userId);
            if (accountData == null)
            {
                return 0;
            }
            int accountId = accountData.Id;
            return accountId;
        }

        public bool SaveCharacterData(int accountId, CharacterData data)
        {
            CharacterDataEntity character = _dbContext.CharacterData.SingleOrDefault(character => character.AccountId == accountId);
            
            if (character == null)
            {
                int emptyCharacterId = _dbContext.CharacterData.Count() + 1;
                CharacterDataEntity newCharacter = new CharacterDataEntity(emptyCharacterId, accountId);
                _dbContext.CharacterData.Add(newCharacter);

                // int emptyWeaponId = _dbContext.WeaponData.Count() + 1;
                string weaponUid = CreateWeaponId(accountId);
                WeaponDataEntity newWeapon = new WeaponDataEntity(weaponUid, accountId);
                _dbContext.WeaponData.Add(newWeapon);

                _dbContext.SaveChanges();

                if (emptyCharacterId != _dbContext.CharacterData.Count())
                {
                    _logger.LogError("character id is not correct.");
                    return false;
                }
            }
            else
            {
                character.SaveCharactereData(data);
                SaveWeaponData(accountId, data);
                _dbContext.SaveChanges();
            }

            return true;
        }

        public void SaveWeaponData(int accountId, CharacterData data)
        {
            foreach (WeaponData weaponData in data.weapon_data)
            {
                // string weaponId = CreateWeaponId(accountId);
                string weaponUid = weaponData.unique_id;
                if (weaponUid == "NewWeapon")
                {
                    weaponUid = CreateWeaponId(accountId);
                    AddWeapon(weaponUid, accountId, weaponData);
                    _logger.LogDebug("Success to Add Weapon");
                    continue;
                }

                WeaponDataEntity weapon = _dbContext.WeaponData.SingleOrDefault(weapon => weapon.Uid == weaponUid);
                if (weapon == null)
                {
                    _logger.LogError("Error");
                    continue;
                }

                UpdateWeapon(weapon, weaponData);

            }
        }

        private void UpdateWeapon(WeaponDataEntity weapon, WeaponData weaponData)
        {
            weapon.Level = weaponData.level;
            weapon.Enhancement = weaponData.enhancement;
        }

        private void AddWeapon(string weaponId, int accountId, WeaponData data)
        {
            WeaponDataEntity entity = new WeaponDataEntity(weaponId, accountId, data);
            _dbContext.WeaponData.Add(entity);
        }

        private string CreateWeaponId(int accountId)
        {
            string weaponId = Guid.NewGuid().ToString();

            return MakeWeaponKey(accountId, weaponId);
        }

        private string MakeWeaponKey(int accountId, string weaponId)
        {
            return $"{accountId}:{weaponId}";
        }

        public CharacterData LoadCharacterData(int accountId)
        {
            CharacterDataEntity savedData = _dbContext.CharacterData.SingleOrDefault(character => character.AccountId == accountId);
            if (savedData == null)
            {
                return null;
            }

            CharacterData characterData = new CharacterData();
            characterData.level = savedData.Level;
            characterData.exp = savedData.Exp;
            characterData.player_name = savedData.Name;
            characterData.gold = savedData.Gold;

            return characterData;
        }
    }
}

