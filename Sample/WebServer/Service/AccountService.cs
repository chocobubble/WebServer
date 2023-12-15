using WebServer.Controllers;
using WebServer.Model;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    private ILogger<AccountService> _logger { get; }
    public AccountService(ILogger<AccountService> logger, IAccountRepository accountRepository)
    {
        _logger = logger;
        _accountRepository = accountRepository;
    }


    public bool AddAccount(string userName, string userPassword)
    {

        _logger.LogError("AddAccount");

        _accountRepository.Save(userName, userPassword);

        return true;
    }
}