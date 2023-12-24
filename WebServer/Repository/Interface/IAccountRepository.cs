using System;
using WebServer.Model;

namespace WebServer.Repository.Interface
{
	public interface IAccountRepository
	{
		public bool CreateAccount(string inputId, string inputPwd);
		public bool IsEnrolledAccount(string inputId);
		public bool IsCorrectPassword(string inputId, string inputPwd);
    }
}

