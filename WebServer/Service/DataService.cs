using WebServer.Model;
using WebServer.Service.Interface;
using WebServer.Repository.Interface;

namespace WebServer.Service
{
    public class DataService : IDataService
    {
        private readonly ICharacterDataRepository _characterDataRepository;
        private readonly ISessionRepository _sessionRepository;

        public DataService(ICharacterDataRepository characterDataRepository, ISessionRepository sessionRepository)
        {
            _characterDataRepository = characterDataRepository;
            _sessionRepository = sessionRepository;
        }

        public bool SaveCharacterData(string sessionId, CharacterData data)
        {
            _sessionRepository.RefreshSessionId(sessionId);
            string userId = _sessionRepository.GetUserIdFromSessionId(sessionId);
            if (!_characterDataRepository.HasCharacterData(userId))
            {
                _characterDataRepository.AddCharacterData(userId, data);
            }
            else
            {
                _characterDataRepository.SaveCharacterData(userId, data);
            }
            Console.WriteLine("Save Character Data in service");
            return true;
        }

        public CharacterData LoadCharacterData(string sessionId)
        {
            _sessionRepository.RefreshSessionId(sessionId);
            string userId = _sessionRepository.GetUserIdFromSessionId(sessionId);
            if (!_characterDataRepository.HasCharacterData(userId))
            {
                // TODO : CharacterData 내부에 유효한 데이터 검증 변수 넣기
                CharacterData data = new CharacterData();
                data.playerName = "Invalid";
                return data;
            }

            return _characterDataRepository.LoadCharacterData(userId);
        }

    }
}
