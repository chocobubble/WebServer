using Microsoft.AspNetCore.Mvc;
using WebServer.Model;



namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        static private AccountManager _accountManager = new AccountManager();

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }


    }
}