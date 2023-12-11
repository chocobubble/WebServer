using System;
using WebServer.Model;

namespace WebServer.Service.Interface
{
	public interface IAccountService
	{
        public string CreateAccount(string id, string pwd);
        public string Login(string userId, string userPwd);
        public string LogOut(string userId);
        public void TestCreateAccounts(int num);
    }
}

