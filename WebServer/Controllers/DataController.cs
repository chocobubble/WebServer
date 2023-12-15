using Microsoft.AspNetCore.Mvc;
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
        private readonly LoadService _loadService;
        private readonly SaveService _saveService;

        public DataController(ILogger<DataController> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _loadService = new LoadService(accountRepository);
            _saveService = new SaveService(accountRepository);
        }

        [HttpPost]
        public string SaveCharacterData(string userName, byte[] bytes)
        {
            _saveService.SaveData(userName, bytes);
            return "캐릭터 데이터 저장에 성공했습니다";
        }

        [HttpGet]
        public byte[] LoadCharacterData(string userId)
        {
            return _loadService.LoadData(userId);
        }
    }
}