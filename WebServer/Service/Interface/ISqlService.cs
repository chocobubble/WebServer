using System;
using WebServer.Model;

namespace WebServer.Service.Interface
{
	public interface ISqlService
	{
		public bool CreateAccount(string inputId, string inputPwd);
		public bool IsValidId(string inputId);
		public bool IsValidPassword(string inputId, string inputPwd);
		public int GetAccountId(string userId);
		public bool SaveCharacterData(int accountId, CharacterData data);
		public CharacterData LoadCharacterData(int accountId);
    }
}

