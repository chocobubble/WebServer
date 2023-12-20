using WebServer.Model;
using WebServer.Service.Interface;
using WebServer.Repository.Interface;

namespace WebServer.Service
{
    public class DataService : IDataService
    {
        private ICharacterDataRepository _characterDataRepository;

        public DataService(ICharacterDataRepository characterDataRepository)
        {
            _characterDataRepository = characterDataRepository;
        }

        public bool SaveCharacterData(string userId, CharacterData data)
        {
            if (!_characterDataRepository.HasCharacterData(userId))
            {
                _characterDataRepository.AddCharacterData(userId, data);
            }
            else
            {
                _characterDataRepository.SaveCharacterData(userId, data);
            }

            return true;
        }

        public CharacterData LoadCharacterData(string userId)
        {
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
