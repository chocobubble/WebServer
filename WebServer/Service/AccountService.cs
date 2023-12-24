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

        public AccountService(ILogger<AccountController> logger, IAccountRepository accountRepository)
		{
            _logger = logger;
            _accountRepository = accountRepository;
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

    }
}

