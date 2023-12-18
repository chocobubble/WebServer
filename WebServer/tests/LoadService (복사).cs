using WebServer.Model;
using WebServer.Repository;
using WebServer.Service.Interface;
using WebServer.Protos;
using Google.Protobuf;
using WebServer.Repository.Interface;

namespace WebServer.Test
{
    /*
    public class LoadService
    {
        private IAccountRepository _accountRepository;

        public LoadService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public byte[] LoadData(string userId)
        {
            byte[] bytes = _accountRepository.GetUserCharacterData(userId).ToByteArray();
            return bytes;
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
    */
}
