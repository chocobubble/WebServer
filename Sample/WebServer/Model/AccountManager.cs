using Microsoft.OpenApi.Any;
using System.Collections;
using System.Collections.Immutable;

namespace WebServer.Model
{
    public class AccountManager
    {

        public AccountManager() 
        {
            _accountTable = new Dictionary<string, AccountInfo>();
            _accountList = new List<AccountInfo>();
        }

        //////// account ////////
        public bool AddAccount(string userName, string userPassword)
        {
            if (_accountTable.ContainsKey(userName))
            {
                return false;
            }
            else
            {
                AccountInfo newAccountInfo = new AccountInfo(userName, userPassword);
                _accountTable.Add(userName, newAccountInfo);
                _accountList.Add(newAccountInfo);
                return true;
            }
        }

        public string Login(string userName, string userPassword) 
        {
            if (!_accountTable.ContainsKey(userName))
            {
                return "없는 계정입니다.";
            }
            else if (userPassword != _accountTable[userName].UserPassword)
            {
                return "비밀번호가 틀립니다.";
            }
            else
            {
                _logInUserName = userName;
                return "로그인 되었습니다.";
            }

        }

        public string LogOut()
        {
            _logInUserName = "";
            return "로그아웃 되었습니다.";
        }

        public string PrintLoginUserInfo()
        {
            if (_logInUserName == "")
            {
                return "로그인을 먼저 해야 함 ";
            }

            return _accountTable[_logInUserName].PrintAccountInfo();

        }

        ////////////////////////


        //////// 점수 ////////
        public bool SetScore(string userName, int score)
        {
            if (!_accountTable.ContainsKey(userName))
            {
                return false;
            }
            else
            {
                AccountInfo tempAccount = _accountTable[userName];
                tempAccount.Score = score;
                return true;
            }
        }

        public int GetUserRank(string id)
        {
            _accountList.Sort();
            for (int idx = 0; idx < _accountList.Count; idx++)
            {
                if (_accountList[idx].PlayerId == id)
                {
                    return idx + 1;
                }
            }
            return -1;
        }


        public string GetLoginUserRank()
        {
            if (_logInUserName == "")
            {
                return "로그인을 먼저 해야합니다.";
            }

            int myRank = GetUserRank(_logInUserName);
            if (myRank != -1)
            {
                return $"내 랭킹은 {myRank}입니다.";
            }
            else
            {
                return "에러";
            }
        }

        public string PrintAllScorer()
        {
            if (_accountList.Count == 0)
            {
                return "계정이 존재하지 않습니다.";
            }

            string print = "";
            _accountList.Sort();
            for (int idx = 0; idx < _accountList.Count; idx++)
            {
                print += $"{idx + 1}등 유저의 아이디는 {_accountList[idx].PlayerId}이고, 점수는 {_accountList[idx].Score} 입니다.\n";
            }
            return print;
        }
        ////////////////////////

        //////// 골드 ////////
        public bool SetGold(string userName, int gold)
        {
            if (!_accountTable.ContainsKey(userName))
            {
                return false;
            }
            else
            {
                AccountInfo tempAccount = _accountTable[userName];
                tempAccount.Gold = gold;
                return true;
            }
        }

        public bool SetLogInUserGold(int gold)
        {
            if (_logInUserName == "")
            {
                return false;
            }
            else
            {
                _accountTable[_logInUserName].Gold = gold;
                return true;
            }
        }

        public int GetLoginUserGold()
        {
            int gold = -1;
            if (_logInUserName == "")
            {
                return gold;
            }
            gold = _accountTable[_logInUserName].Gold;
            return gold;
        }

        public bool LoginUserGetItem(Item item)
        {
            if (_logInUserName == "")
            {
                return false;
            }

            _accountTable[_logInUserName].Items.Add(item);
            return true;
        }


        //////// TEST ////////
        public void CreateAccounts(int num)
        {
            for (int i = 0; i < num; i++)
            {
                AddAccount(i.ToString(), i.ToString());
                SetScore(i.ToString(), 500 - i);
                SetGold(i.ToString(), 2000);
            }
        }
        ////////////////////////

        private Dictionary<string, AccountInfo> _accountTable;

        private List<AccountInfo> _accountList;
        
        private string _logInUserName = "";

    }

    public class AccountInfo : IComparable<AccountInfo>
    {

        public AccountInfo(string playerId, string userPassword)
        {
            PlayerId = playerId;
            UserPassword = userPassword;
            Items = new List<Item>();
        }

        public string PrintAccountInfo()
        {
            string res = "";
            res += $"id : {PlayerId}, Score : {Score}, Gold : {Gold}\n";
            res += "보유중인 아이템\n";
            foreach (Item item in Items)
            {
                res += item.ShowInfo();
            }
            return res;

        }


        public int CompareTo(AccountInfo other)
        {
            if (other == null) return -1;
            return other.Score - this.Score;
        }

        public string PlayerId { get; set; }
        public string UserPassword { get; set; }
        public int Score { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Ammo { get; set; }
        public List<Item> Items { get; set; }
    }
}
