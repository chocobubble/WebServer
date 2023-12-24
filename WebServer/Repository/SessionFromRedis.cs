using System;
using WebServer.Repository.Interface;
using StackExchange.Redis;

namespace WebServer.Repository
{
    public struct SessionExpireTime
    {
        public SessionExpireTime()
        {
            hours = 0;
            minutes = 10;
            seconds = 0;
        }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
    }

	public class SessionFromRedis : ISessionRepository
    {
        private IDatabase sessionDb;
        private SessionExpireTime sessionExpireTime = new SessionExpireTime();
        private TimeSpan timeSpan = new TimeSpan(0, 10, 0);

        public SessionFromRedis()
		{
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { "127.0.0.1:6379" }
            });

            sessionDb = redisConnection.GetDatabase(1);
            Console.WriteLine(sessionDb.Ping());
            Console.WriteLine(redisConnection.IsConnected);
        }

        public string CreateSessionId(string userId)
        {
            string sessionId = Guid.NewGuid().ToString();
            sessionDb.StringSet(MakeSessionKey(sessionId), userId, new TimeSpan(sessionExpireTime.hours, sessionExpireTime.minutes, sessionExpireTime.seconds));
            sessionDb.StringSet(MakeUserKey(userId), sessionId, new TimeSpan(sessionExpireTime.hours, sessionExpireTime.minutes, sessionExpireTime.seconds));
            return sessionId;
        }

        private string MakeSessionKey(string sessionId)
        {
            return $"SessionId:{sessionId}";
        }

        private string MakeUserKey(string userId)
        {
            return $"UserId:{userId}";
        }

        public bool DeleteSessionId(string sessionId)
        {
            string? userId = sessionDb.StringGet(MakeSessionKey(sessionId));
            if (userId != null)
            {
                sessionDb.KeyDelete(MakeSessionKey(sessionId));
                sessionDb.KeyDelete(MakeUserKey(userId));
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetUserIdFromSessionId(string sessionId)
        {
            return sessionDb.StringGet(MakeSessionKey(sessionId));
        }

        public bool IsDuplicatedLogin(string sessionId)
        {
            if (sessionDb.StringGet(MakeSessionKey(sessionId)) != RedisValue.Null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidSession(string sessionId)
        {
            return sessionDb.StringGet(MakeSessionKey(sessionId)) != RedisValue.Null;
        }

        public bool IsValidSessionId(string sessionId)
        {
            return sessionDb.StringGet(MakeSessionKey(sessionId)) != RedisValue.Null;
        }

        public bool RefreshSessionId(string sessionId)
        {
            string? userId = sessionDb.StringGet(MakeSessionKey(sessionId));
            if (userId == null)
            {
                return false;
            }
            else
            {
                sessionDb.KeyExpire(MakeSessionKey(sessionId), timeSpan);
                sessionDb.KeyExpire(MakeUserKey(userId), timeSpan);
                return true;
            }
        }
    }
}

