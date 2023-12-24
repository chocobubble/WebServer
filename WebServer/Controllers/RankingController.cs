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
        private readonly IRankingService _rankingService;
        private readonly ISessionService _sessionService;

        public RankingController(ILogger<RankingController> logger, IRankingService rankingService, ISessionService sessionService)
        {
            _logger = logger;
            _rankingService = rankingService;
            _sessionService = sessionService;
        }

        [HttpPost]
        public RankResponse GetRank(RankRequest request)
        {
            RankResponse response = new RankResponse();
            if (_sessionService.IsValidSessionId(request.sessionId))
            {
                response.ranking = _rankingService.GetRank(request.sessionId);
                response.apiReturnCode = ApiReturnCode.Success;
            }
            else
            {
                response.ranking = -1;
                response.apiReturnCode = ApiReturnCode.InvalidSessionId;
            }
            return response;
        }
    }
}

