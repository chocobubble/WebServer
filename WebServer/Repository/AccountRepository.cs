using System;
using WebServer.Model;
using WebServer.Repository.Interface;

namespace WebServer.Repository
{
	public class AccountRepository : IAccountRepository
	{
		//private AccountManager _accountManager;
        private Dictionary<string, AccountInfo> _accountTable;

        public AccountRepository()
		{
			//_accountManager = new AccountManager();
            _accountTable = new Dictionary<string, AccountInfo>();
        }

		public bool CreateAccount(string userId, string userPwd)
		{
            if (_accountTable.ContainsKey(userId))
            {
                return false;
            }
            else
            {
                AccountInfo newAccountInfo = new AccountInfo(userId, userPwd);
                _accountTable.Add(userId, newAccountInfo);
                return true;
            }
		}

        public AccountInfo? GetUserInfo(string userId, string userPwd)
		{
            if (_accountTable.ContainsKey(userId))
            {
                if (_accountTable[userId].UserPassword == userPwd)
                {
                    return _accountTable[userId];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }

    }
}

