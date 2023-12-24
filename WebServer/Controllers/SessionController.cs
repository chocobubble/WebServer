using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Repository;
using WebServer.Repository.Interface;
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
        //private readonly ISessionService _sessionService;
        private readonly ISessionRepository _sessionFromRedis;

        public SessionController(ILogger<SessionController> logger, IAccountService accountService, ISessionRepository sessionRepository)
        {
            this._logger = logger;
            this._accountService = accountService;
            //this._sessionService = sessionService;
            this._sessionFromRedis = sessionRepository;
        }
        
        [HttpPost]
        public LoginResponse Login(LoginRequest loginRequest)
        {
            string userId = loginRequest.id;
            string userPwd = loginRequest.password;
            LoginResponse loginResponse = new LoginResponse();
            if (!_accountService.IsValidId(userId))
            {
                _logger.Log(LogLevel.Warning, "Wrong Id");
                loginResponse.apiReturnCode = ApiReturnCode.InvalidUserId;
            }
            else if (!_accountService.IsValidPassword(userId, userPwd))
            {

                _logger.Log(LogLevel.Warning, "Wrong Password");
                loginResponse.apiReturnCode = ApiReturnCode.InvalidUserPassword;
            }
            else
            {
                _logger.Log(LogLevel.Warning, "Login Success");
                loginResponse.apiReturnCode = ApiReturnCode.Success;
                //loginResponse.sessionId = _sessionService.CreateSessionId(userId);
                loginResponse.sessionId = _sessionFromRedis.CreateSessionId(userId);
            }
            return loginResponse;
        }

        [HttpPost]
        public LogoutResponse LogOut(LogoutRequest logoutRequest)
        {
            //_sessionService.DeleteSessionId(logoutRequest.sessionId);
            _sessionFromRedis.DeleteSessionId(logoutRequest.sessionId);

            LogoutResponse logoutResponse = new LogoutResponse();
            logoutResponse.apiReturnCode = ApiReturnCode.Success;

            return logoutResponse;
        }

        [HttpPost]
        public RefreshSessionResponse RefreshSession(RefreshSessionRequest refreshSessionRequest)
        {
            string requestSessionId = refreshSessionRequest.sessionId;

            RefreshSessionResponse refreshSessionResponse = new RefreshSessionResponse();

            //if (_sessionService.IsValidSessionId(requestSessionId))
            if (_sessionFromRedis.IsValidSessionId(requestSessionId))
            {
                //_sessionService.RefreshSessionId(requestSessionId);
                _sessionFromRedis.RefreshSessionId(requestSessionId);
                // 중복 로그인 된 상태인지 확인
                //if (_sessionService.IsDuplicatedLogin(requestSessionId))
                if (_sessionFromRedis.IsDuplicatedLogin(requestSessionId))
                {
                    refreshSessionResponse.apiReturnCode = ApiReturnCode.DuplicatedLogin;
                }
                else
                {
                    refreshSessionResponse.apiReturnCode = ApiReturnCode.Success;
                }
            }
            else
            {
                refreshSessionResponse.apiReturnCode = ApiReturnCode.InvalidSessionId;
            }

            return refreshSessionResponse;
        }
    }
}