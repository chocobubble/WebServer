using WebServer.Model;
using WebServer.Repository;
using WebServer.Service.Interface;
using WebServer.Protos;
using Google.Protobuf;
using WebServer.Repository.Interface;

namespace WebServer.Service
{
    public class LoadService
    {
        private ICharacterDataRepository _characterDataRepository;

        public LoadService(ICharacterDataRepository characterDataRepository)
        {
            _characterDataRepository = characterDataRepository;
        }

        public string LoadData()
        {
            string res = $"Level : {_characterDataRepository.GetCharacterData().Level}\n";
            res += $"PlayerName : {_characterDataRepository.GetCharacterData().PlayerName}\n";
            return res;
        }

        public string ProtoTest()
        {
            CharacterData _data = new CharacterData();
            _data.PlayerName = "proto";
            _data.Level = 5;

            //byte[] bytes = _data.ToByteArray();
            using (var output = File.Create("john.dat"))
            {
                _data.WriteTo(output);
            }

            CharacterData updatedData;
            using (var input = File.OpenRead("john.dat"))
            {
                updatedData = CharacterData.Parser.ParseFrom(input);
            }
            return updatedData.PlayerName;

        }

        public byte[] GetBytes()
        {
            CharacterData _data = new CharacterData();
            _data.PlayerName = "proto";
            _data.Level = 5;
            return _data.ToByteArray();
        }

    }
}
