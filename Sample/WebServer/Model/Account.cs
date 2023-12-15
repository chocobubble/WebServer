using System.Collections;
/*
namespace WebServer.Model
{
    public class Account
    {
        public int TotalAccountNumber { get; set; }

        private Dictionary<string, AccountInfo> table;

        public Account() 
        {
            table = new Dictionary<string, AccountInfo>();
        }

        public void AddAccount(string accountName, string accountPassword)
        {
            AccountInfo newAccountInfo = new AccountInfo(accountName, accountPassword);
            table.Add(accountName, newAccountInfo);
        }

        public string PrintAccountInfo(string accountName) 
        {
            if (table.ContainsKey(accountName))
            {
                return table[accountName].UserPassword;
            }
            else
            {
                return "The ID isn't in the pool";
            }
        }

        public string GetAccountNumber() 
        {
            int n = table.Count;
            return $"{n} 개의 아이디가 있습니다.";
        }
    }

    public class AccountInfo
    {
        public AccountInfo() 
        {
            PlayerId = "";
            UserPassword = "";
        }

        public AccountInfo(string playerId, string userPassword)
        {
            PlayerId = playerId;
            UserPassword = userPassword;
        }

        public string PlayerId { get; set; }
        public string UserPassword { get; set; }
    }
}
*/