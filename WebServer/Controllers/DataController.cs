using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Model;
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
        private readonly IDataService _dataService;
        private readonly ISessionService _sessionService;

        public DataController(ILogger<DataController> logger, IDataService dataService, ISessionService sessionService)
        {
            _logger = logger;
            _dataService = dataService;
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

        [HttpPost]
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
            else // 캐릭터 데이터 로딩 성공
            {
                CharacterData loadData = _dataService.LoadCharacterData(request.sessionId);
                response.characterData = loadData;
                response.apiReturnCode = ApiReturnCode.Success;
            }

            return response;
        }

        [HttpPost]
        public CharacterDataSaveRequest ProtoTest(CharacterDataSaveRequest request)
        {

            return request;
        }

        [HttpPost]
        public CharacterDataLoadResponse ProtoTest2(CharacterDataLoadResponse response)
        {

            return response;
        }
    }
}