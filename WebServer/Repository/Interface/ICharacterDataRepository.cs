using WebServer.Model;

namespace WebServer.Repository.Interface
{
    public interface ICharacterDataRepository
    {
        public void SaveCharacterData(string userId, CharacterData characterData);
        public void AddCharacterData(string userId, CharacterData characterData);
        public bool HasCharacterData(string userId);
        public CharacterData LoadCharacterData(string userId);
        public void SortRankingList();
        public int GetRank(string userId);
    }
}
