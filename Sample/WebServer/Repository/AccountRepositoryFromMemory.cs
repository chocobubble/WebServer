
using WebServer.Model;

public class AccountRepositoryFromMemoery : IAccountRepository
{
    private Dictionary<string, AccountInfo> _accountTable;

    public AccountRepositoryFromMemoery(ILogger<AccountRepositoryFromMemoery> logger)
    {
        _accountTable = new Dictionary<string, AccountInfo>();
    }

    public void Save(string userName, string userPassword)
    {
        _accountTable.Add(userName, new AccountInfo("1", "2"));
    }
}