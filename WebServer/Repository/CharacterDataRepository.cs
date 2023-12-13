using WebServer.Protos;
using WebServer.Repository.Interface;


namespace WebServer.Repository
{

    public class CharacterDataRepository : ICharacterDataRepository
    {
        public CharacterData _characterData { get; set; }

        public CharacterDataRepository()
        {
            _characterData = new CharacterData();
        }

        public void SaveData()
        {

        }
        public void LoadData()
        {

        }
        public CharacterData GetCharacterData()
        {
            return _characterData;
        }
    }
}
