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



        /*
        [HttpPost]
        public string CreateAccount(string userId, string userPwd)
        {
            return _accountService.CreateAccount(userId, userPwd);
        }

        
        [HttpPost]
        public string Login(string userId, string userPwd)
        {
            return _accountService.Login(userId, userPwd);
        }

        [HttpPost]
        public string Login(string userId, string userPwd)
        {
            if (!_accountService.IsValidId(userId))
            {
                return "Invalid_Id";
            }
            else if (!_accountService.IsValidPassword(userId, userPwd))
            {
                return "Invalid_Pwd";
            }

            return "";
        }

        [HttpPost]
        public string LogOut(string userId)
        {
            return _accountService.LogOut(userId);
        }

        [HttpPost]
        public void CreateAccounts(int num)
        {
            _accountService.TestCreateAccounts(num);
        }*/
    }
}