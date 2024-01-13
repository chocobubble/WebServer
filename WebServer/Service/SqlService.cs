using System;
using WebServer.Controllers;
using WebServer.Model;
using WebServer.Repository.Interface;
using WebServer.Service.Interface;

namespace WebServer.Service
{
    public class SqlService : ISqlService
    {
        private ILogger<SqlService> _logger;
        private AccountDbContext dbContext = new AccountDbContext();

        public SqlService(ILogger<SqlService> logger)
        {
            _logger = logger;
        }

        public bool CreateAccount(string inputId, string inputPwd)
        {
            int emptyId = dbContext.Account.Count() + 1;
            AccountData newAccount = new AccountData(emptyId, inputId, inputPwd);
            dbContext.Account.Add(newAccount);
            dbContext.SaveChanges();

            if (emptyId != dbContext.Account.Count())
            {
                return false;
            }

            return true;
        }

        public bool IsValidId(string inputId)
        {
            if (dbContext.Account.Any(account => account.UserId == inputId))
            {
                return true;
            }
            return false;
        }

        public bool IsValidPassword(string inputId, string inputPwd)
        {
            AccountData accountData = dbContext.Account.SingleOrDefault(account => account.UserId == inputId && account.UserPassword == inputPwd);
            if (accountData == null)
            {
                return false;
            }
            return true;
        }

        public int GetAccountId(string userId)
        {
            AccountData accountData = dbContext.Account.SingleOrDefault(account => account.UserId == userId);
            if (accountData == null)
            {
                return 0;
            }
            int accountId = accountData.Id;
            return accountId;
        }

        public bool SaveCharacterData(int accountId, CharacterData data)
        {
            Character character = dbContext.CharacterData.SingleOrDefault(character => character.AccountId == accountId);
            
            if (character == null)
            {
                int emptyId = dbContext.CharacterData.Count() + 1;
                Character newCharacter = new Character(emptyId, accountId, data);
                dbContext.CharacterData.Add(newCharacter);
                dbContext.SaveChanges();

                if (emptyId != dbContext.CharacterData.Count())
                {
                    return false;
                }
            }
            else
            {
                character.SaveCharactereData(data);
                dbContext.SaveChanges();
            }

            return true;
        }

        public CharacterData LoadCharacterData(int accountId)
        {
            Character savedData = dbContext.CharacterData.SingleOrDefault(character => character.AccountId == accountId);
            if (savedData == null)
            {
                return null;
            }

            CharacterData characterData = new CharacterData();
            characterData.level = savedData.Level;
            characterData.exp = savedData.Exp;
            characterData.playerName = savedData.Name;
            characterData.gold = savedData.Gold;
            characterData.weaponData = new WeaponData();
            characterData.weaponData.weaponType = (WeaponType)savedData.WeaponType;
            characterData.weaponData.weaponLevel = savedData.WeaponLevel;
            characterData.weaponData.weaponEnhancementLevel = savedData.WeaponEnhancementLevel;
            characterData.rifleAmmo = savedData.RifleAmmo;
            return characterData;
        }
    }
}

