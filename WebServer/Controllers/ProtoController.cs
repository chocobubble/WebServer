using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Repository.Interface;
using WebServer.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProtoController : ControllerBase
    {
        private readonly ILogger<ProtoController> _logger;

        private ProtoTestService _protoTestService;

        private LoadService _loadService;

        public ProtoController(ILogger<ProtoController> logger, ICharacterDataRepository characterDataRepository)
        {
            _logger = logger;
            _protoTestService = new ProtoTestService();
            _loadService = new LoadService(characterDataRepository);
        }
        /*
        [HttpGet]
        public string Hello()
        {
            return _protoTestService.Hello();
        }

        [HttpGet]
        public string NewHello()
        {
            return _protoTestService.SerializeHello();
        }
        */
        [HttpGet]
        public string LoadCharacterData()
        {
            return _loadService.ProtoTest();
        }
    }
}

