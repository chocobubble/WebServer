using System;
using StackExchange.Redis;
using WebServer.Model;
using WebServer.Repository.Interface;

namespace WebServer.Repository
{
	public class RankFromRedis : IRankRepository
    {
        private IDatabase rankDb;
        private string worldRanking = "WorldRanking";

        public RankFromRedis()
		{
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { "127.0.0.1:6379" }
            });

            rankDb = redisConnection.GetDatabase(3);
        }

        long? IRankRepository.GetMyRank(string userId)
        {
            return rankDb.SortedSetRank(worldRanking, userId, Order.Descending);
        }

        List<string> IRankRepository.GetRanks(int startRank, int count)
        {
            RedisValue[] redisValues = rankDb.SortedSetRangeByRank(worldRanking, startRank - 1, count, Order.Descending);
            List<string> ranks = redisValues.Select(redisValue => (string)redisValue).ToList();

            for (int i = 0; i < ranks.Count(); ++i)
            {
                Console.WriteLine($"{i + startRank} : {ranks[i]}");
            }
            return ranks;
        }

        bool IRankRepository.UpdateRank(string userId, int level)
        {
            rankDb.SortedSetAdd(worldRanking, userId, level);
            return true;
        }
    }
}

