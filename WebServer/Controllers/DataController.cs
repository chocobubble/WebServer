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

        public DataController(ILogger<DataController> logger, ICharacterDataRepository characterDataRepository)
        {
            _logger = logger;
            _loadService = new LoadService(characterDataRepository);
            _saveService = new SaveService(characterDataRepository);
        }

        [HttpPost]
        public string SaveCharacterData(string userName, int level)
        {
            _saveService.SaveData(userName, level);
            return "캐릭터 데이터 저장에 성공했습니다";
        }

        [HttpGet]
        public string LoadCharacterData()
        {
            string res = "";
            res += _loadService.LoadData();
            res += "캐릭터 데이터 불러오기에 성공했습니다\n";
            return res;
        }
    }
}