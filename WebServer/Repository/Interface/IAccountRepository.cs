using System;
using WebServer.Model;

namespace WebServer.Repository.Interface
{
	public interface IAccountRepository
	{
		public bool CreateAccount(string userId, string userPwd);
		public AccountInfo GetUserInfo(string userId, string userPwd);

    }
}

