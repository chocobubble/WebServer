using Microsoft.AspNetCore.Mvc;
using WebServer.Model;
using WebServer.Service;
using WebServer.Service.Interface;

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class SessionController : ControllerBase
    { 
        private readonly ILogger<SessionController> _logger;
        private readonly IAccountService _accountService;
        private readonly ISessionService _sessionService;

        public SessionController(ILogger<SessionController> logger, IAccountService accountService, ISessionService sessionService)
        {
            this._logger = logger;
            this._accountService = accountService;
            this._sessionService = sessionService;
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

            return _sessionService.CreateSessionId(userId);
        }

        [HttpPost]
        public string LogOut(string sessionId)
        {
            if (!_sessionService.DeleteSessionId(sessionId))
            {
                return "fail";
            }
            return "success";
        }
    }
}