using System;
using WebServer.Model;

namespace WebServer.Service.Interface
{
	public interface IAccountService
	{
        public bool CreateAccount(string inputId, string inputPwd);
        public bool IsValidId(string inputId);
        public bool IsValidPassword(string inputId, string inputPwd);
    }
}

