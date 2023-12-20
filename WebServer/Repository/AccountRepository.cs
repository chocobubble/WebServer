using System;
using WebServer.Model;
using WebServer.Repository.Interface;

namespace WebServer.Repository
{
	public class AccountRepository : IAccountRepository
	{
        private Dictionary<string, AccountData> _accountTable;

        public AccountRepository()
		{
            _accountTable = new Dictionary<string, AccountData>();
        }

		public bool CreateAccount(string inputId, string inputPwd)
		{
            if (_accountTable.ContainsKey(inputId))
            {
                return false;
            }
            else
            {
                AccountData newAccountData = new AccountData(inputId, inputPwd);
                _accountTable.Add(inputId, newAccountData);
                return true;
            }
		}

        public bool IsEnrolledAccount(string inputId)
        {
            if (_accountTable.ContainsKey(inputId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCorrectPassword(string inputId, string inputPwd)
        {
            if (_accountTable[inputId].UserPassword == inputPwd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CharacterData GetUserCharacterData(string userId)
		{
            if (_accountTable.ContainsKey(userId))
            {
                return _accountTable[userId].characterData;
            }
            else
            {
                return null;
            }   
        }
    }
}

