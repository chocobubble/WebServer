using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Model;
using WebServer.Repository;
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

        public DataController(ILogger<DataController> logger, ICharacterDataRepository characterDataRepository)
        {
            _logger = logger;
            _dataService = new DataService(characterDataRepository);
        }

        [HttpPost]
        public CharacterDataSaveResponse SaveCharacterData(CharacterDataSaveRequest request)
        {
            _dataService.SaveCharacterData(request.sessionId, bytes);
            return "캐릭터 데이터 저장에 성공했습니다";
        }

        [HttpGet]
        public byte[] LoadCharacterData(string userId)
        {
            return _dataService.LoadCharacterData(userId);
        }
    }
}