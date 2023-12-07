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
        public string PrintItems()
        {
            return shop.ShowItems();
        }
    }
}