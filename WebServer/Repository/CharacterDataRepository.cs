using WebServer.Model;
using WebServer.Repository.Interface;


namespace WebServer.Deprecated
{

    public class CharacterDataRepository : ICharacterDataRepository
    {
        public Dictionary<string, CharacterData> _userIdToCharacterData;
        public List<string> _RankingList;

        public CharacterDataRepository()
        {
            _userIdToCharacterData = new Dictionary<string, CharacterData>();
            _RankingList = new List<string>();
        }

        public void SaveCharacterData(string userId, CharacterData characterData)
        {
            _userIdToCharacterData[userId] = characterData;
        }

        public void AddCharacterData(string userId, CharacterData characterData)
        {
            _userIdToCharacterData.Add(userId, characterData);
            _RankingList.Add(userId);
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

        public void SortRankingList()
        {
            _RankingList.Sort((a, b) => (
                _userIdToCharacterData[b].level.CompareTo(_userIdToCharacterData[a].level))
            );
        }

        public int GetRank(string userId)
        {
            for (int i = 0; i < _RankingList.Count(); ++i)
            {
                if (userId == _RankingList[i])
                {
                    return i + 1;
                }
            }
            return 0;
        }
    }
}
