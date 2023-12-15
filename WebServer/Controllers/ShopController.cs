using Microsoft.AspNetCore.Mvc;
using WebServer.Model;



namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShopController : ControllerBase
    {

        static private Shop shop = new Shop();


        private readonly ILogger<ShopController> _logger;

        public ShopController(ILogger<ShopController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public string PrintAllItemsInShop()
        {
            return shop.ShowItems();
        }
        /*
        [HttpPost]
        public string PurchaseItem(int idx)
        {
            int myGold = AccountController.accountManagerInstance.GetLoginUserGold();
            if (myGold == -1)
            {
                return "로그인을 먼저 해야합니다 .";
            }

            int price = shop.GetItemPrice(idx);
            if (price == -1)
            {
                return "올바르지 않은 상품입니다.";
            }

            if (price > myGold)
            {
                return "소지하고 있는 골드가 부족 ";
            }

            if (AccountController.accountManagerInstance.SetLogInUserGold(myGold - price))
            {
                if (AccountController.accountManagerInstance.LoginUserGetItem(shop.GetItem(idx)))
                {
                    return "아이템 구매에 성공 ";
                }
                else
                {
                    if (AccountController.accountManagerInstance.SetLogInUserGold(myGold))
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
        */
    }
}