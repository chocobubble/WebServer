using Microsoft.OpenApi.Any;
using System.Collections;
using System.Collections.Immutable;
namespace WebServer.Model
{
    public class AccountData
    {

        public AccountData(string playerId, string userPassword)
        {
            PlayerId = playerId;
            UserPassword = userPassword;
            characterData = new CharacterData();
        }

        public string PlayerId { get; set; }
        public string UserPassword { get; set; }
        public CharacterData characterData { get; set; }
    }
}