using Microsoft.AspNetCore.Mvc;
using WebServer.Model;

// ��ŷ ��Ʈ�ѷ��� �����
// ��ŷ�� �����ϴ� ���
// ��ü ��ŷ�� �ҷ����� ��� (1~100�����)
// ���� ��ŷ�� �ҷ����� ��� (1~100�����)

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class RankingController : ControllerBase
    {

        static private AccountManager _accountManager = new AccountManager();

        private readonly ILogger<RankingController> _logger;

        public RankingController(ILogger<RankingController> logger)
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

        [HttpGet]
        public string GetMyRank()
        {
            return _accountManager.GetLoginUserRank();
        }

        [HttpGet]
        public string PrintAllScorer()
        {
            return _accountManager.PrintAllScorer();
        }

        [HttpPost]
        public void CreateAccounts(int num)
        {
            _accountManager.CreateAccounts(num);
        }
    }
}

