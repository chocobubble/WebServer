using WebServer.Service.Interface;

namespace WebServer.Service
{
    public class LoadService
    {
        private CharacterData _characterData;

        public LoadService()
        {
            _characterData = new CharacterData();
        }

        public string LoadData()
        {
            return "Load complete";
        }

    }
}
