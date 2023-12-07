using Microsoft.AspNetCore.Mvc;
using WebServer.Model;

// 랭킹 컨트롤러를 만들고
// 랭킹을 저장하는 기능
// 전체 랭킹을 불러오는 기능 (1~100등까지)
// 나의 랭킹을 불러오는 기능 (1~100등까지)

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
                return "계정 생성에 성공했습니다.";
            }
            else
            {
                return "계정 생성에 실패했습니다.";
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
                return "스코어 설정에 성공했습니다.";
            }
            else
            {
                return "해당 id가 존재하지 않습니다.";
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

