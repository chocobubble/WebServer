using System.Text.Json;
using StackExchange.Redis;
using WebServer.Model;
using WebServer.Repository.Interface;


namespace WebServer.Repository
{

    public class CharacterDataFromRedis : ICharacterDataRepository
    {
        private IDatabase characterDb;
        private IDatabase protoDb;

        public CharacterDataFromRedis()
        {
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { "127.0.0.1:6379" }
            });
            characterDb = redisConnection.GetDatabase(2);
            protoDb = redisConnection.GetDatabase(4);
        }

        public void SaveCharacterData(string userId, CharacterData characterData)
        {
            string serializedCharacterData = JsonSerializer.Serialize(characterData);
            characterDb.StringSet(userId, serializedCharacterData);
            Console.WriteLine("Save Character Data in repository");
            // TODO: rank 넣
        }

        public void AddCharacterData(string userId, CharacterData characterData)
        {
            string serializedCharacterData = JsonSerializer.Serialize(characterData);
            characterDb.StringSet(userId, serializedCharacterData);
            // TODO: rank 넣기
        }

        public bool HasCharacterData(string userId)
        {
            if (characterDb.StringGet(userId) != RedisValue.Null)
            {
                return true;
            }
            return false;
        }

        public CharacterData LoadCharacterData(string userId)
        {
            string? jsonStr = characterDb.StringGet(userId);
            CharacterData data = new CharacterData();
            if (jsonStr != null)
            {
                data = JsonSerializer.Deserialize<CharacterData>(jsonStr);
            }
            return data;
        }

        public void SortRankingList()
        {
            return;
        }

        public int GetRank(string userId)
        {
            
            return 0;
        }
    }
}
