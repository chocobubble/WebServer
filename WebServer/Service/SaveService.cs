using WebServer.Repository;
using WebServer.Repository.Interface;
using WebServer.Service.Interface;

namespace WebServer.Service
{
    public class SaveService : ISaveService
    {
        private ICharacterDataRepository _characterDataRepository;

        public SaveService(ICharacterDataRepository characterDataRepository)
        {
            _characterDataRepository = characterDataRepository;
        }

        public string SaveData(string name, Int32 level)
        {
            _characterDataRepository.GetCharacterData().PlayerName = name;
            _characterDataRepository.GetCharacterData().Level = level;
            return "Save complete";
        }

    }
}
