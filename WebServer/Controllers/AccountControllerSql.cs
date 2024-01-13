using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Model;
using WebServer.Service.Interface;

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountControllerSql : ControllerBase
    { 
        private readonly ILogger<AccountControllerSql> _logger;
        private readonly ISqlService _sqlService;
        private readonly ISessionService _sessionService;

        public AccountControllerSql(ILogger<AccountControllerSql> logger, ISqlService sqlService, ISessionService sessionService)
        {
            this._logger = logger;
            this._sqlService = sqlService;
            this._sessionService = sessionService;
        }

        [HttpPost]
        public CreateAccountResponse CreateAccountSql(CreateAccountRequest request)
        {
            string userId = request.id;
            string userPwd = request.password;

            CreateAccountResponse response = new CreateAccountResponse();

            if (_sqlService.IsValidId(userId))
            {
                response.apiReturnCode = ApiReturnCode.InvalidUserId;
            }
            else if (!_sqlService.CreateAccount(userId, userPwd))
            {
                response.apiReturnCode = ApiReturnCode.InvalidUserPassword;
            }
            else
            {
                response.apiReturnCode = ApiReturnCode.Success;
            }
            return response; 
        }

        [HttpPost]
        public LoginResponse LoginSql(LoginRequest request)
        {
            string userId = request.id;
            string userPwd = request.password;

            LoginResponse response = new LoginResponse();

            if (!_sqlService.IsValidId(userId))
            {
                response.apiReturnCode = ApiReturnCode.InvalidUserId;
            }
            else if (!_sqlService.IsValidPassword(userId, userPwd))
            {
                response.apiReturnCode = ApiReturnCode.InvalidUserPassword;
            }
            else
            {
                response.apiReturnCode = ApiReturnCode.Success;
                response.sessionId = _sessionService.CreateSessionId(userId);
            }

            return response;
        }

        [HttpPost]
        public CharacterDataSaveResponse SaveCharacterData(CharacterDataSaveRequest request)
        {
            string userSessionId = request.sessionId;
            CharacterDataSaveResponse response = new CharacterDataSaveResponse();

            if (!_sessionService.IsValidSessionId(userSessionId))
            {
                response.apiReturnCode = ApiReturnCode.Fail;
                return response;
            }

            string userId = _sessionService.GetUserIdFromSessionId(userSessionId);
            int accountId = _sqlService.GetAccountId(userId);
            if (accountId == 0) // CharacterDB에 해당 accountId가 없는 경우 
            {
                response.apiReturnCode = ApiReturnCode.Fail;
                return response;
            }

            if (_sqlService.SaveCharacterData(accountId, request.characterData))
            {
                response.apiReturnCode = ApiReturnCode.Success;
            }
            else
            {
                response.apiReturnCode = ApiReturnCode.Fail;
            }

            return response;
        }

        [HttpPost]
        public CharacterDataLoadResponse LoadCharacterData(CharacterDataLoadRequest request)
        {
            string userSessionId = request.sessionId;
            CharacterDataLoadResponse response = new CharacterDataLoadResponse();

            if (!_sessionService.IsValidSessionId(userSessionId))
            {
                response.apiReturnCode = ApiReturnCode.Fail;
                return response;
            }

            string userId = _sessionService.GetUserIdFromSessionId(userSessionId);
            int accountId = _sqlService.GetAccountId(userId);
            if (accountId == 0) // CharacterDB에 해당 accountId가 없는 경우 
            {
                response.apiReturnCode = ApiReturnCode.Fail;
                return response;
            }

            CharacterData characterData = _sqlService.LoadCharacterData(accountId);
            if (characterData == null)
            {
                response.apiReturnCode = ApiReturnCode.Fail;
            }
            else
            {
                response.apiReturnCode = ApiReturnCode.Success;
                response.characterData = characterData;
            }

            return response;
        }
    }
}