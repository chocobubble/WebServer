using System;
using WebServer.Model;

namespace WebServer.Service.Interface
{
	public interface IAccountService
	{
        public string CreateAccount(string inputId, string inputPwd);
        public string Login(string inputId, string inputPwd);
        public string LogOut(string inputId);
        public void TestCreateAccounts(int num);
    }
}

