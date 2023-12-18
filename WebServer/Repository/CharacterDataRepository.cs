using WebServer.Model;
using WebServer.Repository.Interface;


namespace WebServer.Repository
{

    public class CharacterDataRepository : ICharacterDataRepository
    {
        public Dictionary<string, CharacterData> _userIdToCharacterData;

        public CharacterDataRepository()
        {
            _userIdToCharacterData = new Dictionary<string, CharacterData>();
        }

        public void SaveCharacterData(string userId, CharacterData characterData)
        {
            _userIdToCharacterData[userId] = characterData;
        }

        public void AddCharacterData(string userId, CharacterData characterData)
        {
            _userIdToCharacterData.Add(userId, characterData);
        }

        public bool HasCharacterData(string userId)
        {
            if (_userIdToCharacterData.TryGetValue(userId, out _))
            {
                return true;
            }
            return false;
        }

        public CharacterData LoadCharacterData(string userId)
        {
            return _userIdToCharacterData[userId];
        }
    }
}
