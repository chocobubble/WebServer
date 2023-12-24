using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Repository.Interface;
using WebServer.Service.Interface;

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class RedisController : ControllerBase
    { 
        private readonly ILogger<RedisController> _logger;
        private readonly ISessionRepository _sessionFromRedis;

        public RedisController(ILogger<RedisController> logger, ISessionRepository sessionRepository)
        {
            this._logger = logger;
            this._sessionFromRedis = sessionRepository;
        }

        [HttpGet]
        public void Test()
        {

        }
    }
}