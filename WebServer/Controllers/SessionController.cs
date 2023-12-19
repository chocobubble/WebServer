using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
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
        public LoginResponse Login(LoginRequest2 loginRequest)
        {
            string userId = loginRequest.Id;
            string userPwd = loginRequest.Password;
            LoginResponse loginResponse = new LoginResponse();
            if (!_accountService.IsValidId(userId))
            {
                loginResponse.apiReturnCode = ApiReturnCode.InvalidUserId;
            }
            else if (!_accountService.IsValidPassword(userId, userPwd))
            {
                loginResponse.apiReturnCode = ApiReturnCode.InvalidUserPassword;
            }
            else
            {
                loginResponse.apiReturnCode = ApiReturnCode.Success;
                loginResponse.SessionId = _sessionService.CreateSessionId(userId);
            }
            return loginResponse;
        }

        [HttpPost]
        public LoginResponse Login2(LoginRequest loginRequest)
        {
            string userId = loginRequest.Id;
            string userPwd = loginRequest.Password;
            LoginResponse loginResponse = new LoginResponse();
            if (!_accountService.IsValidId(userId))
            {
                loginResponse.apiReturnCode = ApiReturnCode.InvalidUserId;
            }
            else if (!_accountService.IsValidPassword(userId, userPwd))
            {
                loginResponse.apiReturnCode = ApiReturnCode.InvalidUserPassword;
            }
            else
            {
                loginResponse.apiReturnCode = ApiReturnCode.Success;
                loginResponse.SessionId = _sessionService.CreateSessionId(userId);
            }
            return loginResponse;
        }

        [HttpPost]
        public RefreshSessionResponse RefreshSession(RefreshSessionRequest refreshSessionRequest)
        {
            string requestSessionId = refreshSessionRequest.sessionId;

            RefreshSessionResponse refreshSessionResponse = new RefreshSessionResponse();

            if (_sessionService.IsValidSessionId(requestSessionId))
            {
                _sessionService.RefreshSessionId(requestSessionId);
                // 중복 로그인 확인 
                if (_sessionService.IsDuplicatedLogin(requestSessionId))
                {
                    refreshSessionResponse.apiReturnCode = ApiReturnCode.Success;
                }
                else
                {
                    refreshSessionResponse.apiReturnCode = ApiReturnCode.DuplicatedLogin;
                }
            }
            else
            {
                refreshSessionResponse.apiReturnCode = ApiReturnCode.InvalidSessionId;
            }

            return refreshSessionResponse;
        }


        [HttpPost]
        public LogoutResponse LogOut(LogoutRequest logoutRequest)
        {
            _sessionService.DeleteSessionId(logoutRequest.sessionId);

            LogoutResponse logoutResponse = new LogoutResponse();
            logoutResponse.apiReturnCode = ApiReturnCode.Success;
            return logoutResponse;
        }
    }
}