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

        static private Shop _shop = new Shop();

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
        public string PrintMyInfo()
        {
            return _accountManager.PrintLoginUserInfo();
        }

        [HttpGet]
        public string PrintAllScorer()
        {
            return _accountManager.PrintAllScorer();
        }

        [HttpGet]
        public string PrintAllItemsInShop()
        {
            return _shop.ShowItems();
        }

        [HttpPost]
        public string PurchaseItem(int idx)
        {
            int myGold = _accountManager.GetLoginUserGold();
            if (myGold == -1)
            {
                return "로그인을 먼저 해야합니다 .";
            }

            int price = _shop.GetItemPrice(idx);
            if (price == -1)
            {
                return "올바르지 않은 상품입니다.";
            }

            if (price > myGold)
            {
                return "소지하고 있는 골드가 부족 ";
            }

            if (_accountManager.SetLogInUserGold(myGold - price))
            {
                if (_accountManager.LoginUserGetItem(_shop.GetItem(idx)))
                {
                    return "아이템 구매에 성공 ";
                }
                else
                {
                    if (_accountManager.SetLogInUserGold(myGold))
                    {
                        return "아이템 구매에 실패했고 유저 골드 복구에 성공 ";
                    }
                    else
                    {
                        return "아이템 구매 실패 및 유저 골드 복구 실패 ";
                    }
                }
            }
            return "아이템 구매에 실패 ";
        }

        [HttpPost]
        public void CreateAccounts(int num)
        {
            _accountManager.CreateAccounts(num);
        }
    }
}

