using Microsoft.AspNetCore.Mvc;
using WebServer.Model;



namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {

        static private AccountManager _accountManager = new AccountManager();

        public static AccountManager accountManagerInstance
        {
            get
            {
                return _accountManager;
            }
        }
        
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string CreateID(string id, string pwd)
        {
            if (id != "" && _accountManager.AddAccount(id, pwd))
            {
                return "���� ������ �����߽��ϴ�.";
            }
            else
            {
                return "���� ������ �����߽��ϴ�.";
            }
        }

        [HttpPost]
        public string Login(string id, string pwd)
        {
            return _accountManager.Login(id, pwd);
        }

        [HttpPost]
        public string LogOut()
        {
            return _accountManager.LogOut();
        }

        [HttpPost]
        public string SetScore(string id, int score)
        {
            if (_accountManager.SetScore(id, score))
            {
                return "���ھ� ������ �����߽��ϴ�.";
            }
            else
            {
                return "�ش� id�� �������� �ʽ��ϴ�.";
            }
        }

        [HttpPost]
        public void CreateAccounts(int num)
        {
            _accountManager.CreateAccounts(num);
        }
    }
}