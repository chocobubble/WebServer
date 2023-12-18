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

        public bool CreateAccount(string inputId, string inputPwd)
        {
            if (_accountRepository.CreateAccount(inputId, inputPwd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

