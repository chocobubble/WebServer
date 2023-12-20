using WebServer.Model;
using WebServer.Service.Interface;
using WebServer.Repository.Interface;

namespace WebServer.Service
{
    public class RankingService : IRankingService
    {
        private ICharacterDataRepository _characterDataRepository;

        public RankingService(ICharacterDataRepository characterDataRepository)
        {
            _characterDataRepository = characterDataRepository;
        }

        public int GetRank(string userId)
        {
            _characterDataRepository.SortRankingList();
            return _characterDataRepository.GetRank(userId);
        }
    }
}
