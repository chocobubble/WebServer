using WebServer.Model;
using WebServer.Service.Interface;
using WebServer.Repository.Interface;

namespace WebServer.Service
{
    public class RankingService : IRankingService
    {
        private readonly IRankRepository _rankFromRedis;
        private readonly ISessionRepository _sessionRepository;

        public RankingService(IRankRepository rankRepository, ISessionRepository sessionFromRedis)
        {
            _rankFromRedis = rankRepository;
            _sessionRepository = sessionFromRedis;
        }

        public int GetRank(string sessionId)
        {
            _sessionRepository.RefreshSessionId(sessionId);
            string userId = _sessionRepository.GetUserIdFromSessionId(sessionId);
            return (int)_rankFromRedis.GetMyRank(userId);
        }
    }
}
