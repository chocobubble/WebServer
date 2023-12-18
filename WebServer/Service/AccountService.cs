using System;
using WebServer.Controllers;
using WebServer.Model;
using WebServer.Repository.Interface;
using WebServer.Service.Interface;

namespace WebServer.Service
{
	public class AccountService : IAccountService
    {
        private ILogger<AccountController> _logger;
        private IAccountRepository _accountRepository;

        private HashSet<string> _loginUsers;

        public AccountService(ILogger<AccountController> logger, IAccountRepository accountRepository)
		{
            _logger = logger;
            _accountRepository = accountRepository;
            _loginUsers = new HashSet<string>();
        }

        public string CreateAccount(string inputId, string inputPwd)
        {
            if (_accountRepository.CreateAccount(inputId, inputPwd))
            {
                return "계정 생성에 성공했습니다";
            }
            else
            {
                return "계정 생성에 실패했습니다";
            }
        }

        public bool IsValidId(string inputId)
        {
            if (!_accountRepository.IsEnrolledAccount(inputId))
            {
                return false;
            }
            return true;
        }

        public bool IsValidPassword(string inputId, string inputPwd)
        {
            if (!_accountRepository.IsCorrectPassword(inputId, inputPwd))
            {
                return false;
            }
            return true;
        }

        public string LogOut(string inputId)
        {
            if (!_loginUsers.Contains(inputId))
            {
                return "로그인을 먼저 해야합니다";
            }
            else
            {
                _loginUsers.Remove(inputId);
                return "로그아웃 되었습니다";
            }
        }

        public void TestCreateAccounts(int num)
        {
            for (int i = 0; i < num; i++)
            {
                _accountRepository.CreateAccount(i.ToString(), i.ToString());
                //SetScore(i.ToString(), 500 - i);
                //SetGold(i.ToString(), 2000);
            }
            
        }

    }
}

