using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Model;
using WebServer.Service.Interface;

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    { 
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            this._logger = logger;
            this._accountService = accountService;
        }

        [HttpPost]
        public CreateAccountResponse CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse response = new CreateAccountResponse();

            if (_accountService.CreateAccount(request.id,request.password))
            {
                response.apiReturnCode = ApiReturnCode.Success;
            }
            else
            {
                response.apiReturnCode = ApiReturnCode.Fail;
            }
            return response;
        }
    }
}