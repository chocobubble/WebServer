using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Repository.Interface;
using WebServer.Service;
using WebServer.Service.Interface;

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class RankingController : ControllerBase
    {
        private readonly ILogger<RankingController> _logger;
        private readonly RankingService _rankingService;
        private readonly ISessionService _sessionService;

        public RankingController(ILogger<RankingController> logger, ICharacterDataRepository characterDataRepository, ISessionService sessionService)
        {
            _logger = logger;
            _rankingService = new RankingService(characterDataRepository);
            _sessionService = sessionService;
        }

        [HttpPost]
        public RankResponse GetRank(RankRequest request)
        {
            string userId = _sessionService.GetUserIdFromSessionId(request.sessionId);
            RankResponse response = new RankResponse();
            response.ranking = _rankingService.GetRank(userId);
            response.apiReturnCode = ApiReturnCode.Success;
            return response;
        }
    }
}

