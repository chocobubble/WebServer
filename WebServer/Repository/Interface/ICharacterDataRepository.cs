using WebServer.Protos;

namespace WebServer.Repository.Interface
{
    public interface ICharacterDataRepository
    {
        public void SaveData();
        public void LoadData();
        public CharacterData GetCharacterData();
    }
}
