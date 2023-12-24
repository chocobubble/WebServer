using System;
namespace WebServer.Repository.Interface
{
	public interface IRankRepository
	{
        public List<string> GetRanks(int startRank, int count);
        public long? GetMyRank(string userId);
        public bool UpdateRank(string userId, int level);
    }
}

