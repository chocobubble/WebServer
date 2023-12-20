using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Repository.Interface;
using WebServer.Service;
using WebServer.Service.Interface;

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class DataController : ControllerBase
    { 
        private readonly ILogger<DataController> _logger;
        private readonly DataService _dataService;
        private readonly ISessionService _sessionService;

        public DataController(ILogger<DataController> logger, ICharacterDataRepository characterDataRepository, ISessionService sessionService)
        {
            _logger = logger;
            _dataService = new DataService(characterDataRepository);
            _sessionService = sessionService;
        }

        [HttpPost]
        public CharacterDataSaveResponse SaveCharacterData(CharacterDataSaveRequest request)
        {
            CharacterDataSaveResponse response = new CharacterDataSaveResponse();

            if (!_sessionService.IsValidSession(request.sessionId))
            {
                response.apiReturnCode = ApiReturnCode.Fail;
            }
            else if (_sessionService.IsDuplicatedLogin(request.sessionId))
            {
                response.apiReturnCode = ApiReturnCode.DuplicatedLogin;
            }
            else if (!_dataService.SaveCharacterData(request.sessionId, request.characterData))
            {
                response.apiReturnCode = ApiReturnCode.Fail;
            }
            else // 캐릭터 데이터 저장 성공
            {
                response.apiReturnCode = ApiReturnCode.Success;
            }

            return response;
        }

        [HttpGet]
        public CharacterDataLoadResponse LoadCharacterData(CharacterDataLoadRequest request)
        {
            CharacterDataLoadResponse response = new CharacterDataLoadResponse();

            if (!_sessionService.IsValidSession(request.sessionId))
            {
                response.apiReturnCode = ApiReturnCode.Fail;
            }
            else if (_sessionService.IsDuplicatedLogin(request.sessionId))
            {
                response.apiReturnCode = ApiReturnCode.DuplicatedLogin;
            }
            else // 캐릭터 데이터 로 성공
            {
                response.characterData = _dataService.LoadCharacterData(request.sessionId);
                response.apiReturnCode = ApiReturnCode.Success;
            }

            return response;
        }
    }
}