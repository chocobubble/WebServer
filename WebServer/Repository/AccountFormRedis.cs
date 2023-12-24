using System;
using StackExchange.Redis;
using WebServer.Model;
using WebServer.Repository.Interface;

namespace WebServer.Repository
{
	public class AccountFromRedis : IAccountRepository
    {
        private IDatabase accountDb;

        public AccountFromRedis()
		{
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { "127.0.0.1:6379" }
            });

            accountDb = redisConnection.GetDatabase(0);
        }

		public bool CreateAccount(string inputId, string inputPwd)
		{
            if (accountDb.StringGet(inputId) == RedisValue.Null)
            {
                accountDb.StringSet(inputId, inputPwd);
                return true;
            }
            else
            {
                return false;
            }
		}

        public bool IsEnrolledAccount(string inputId)
        {
            if (accountDb.StringGet(inputId) != RedisValue.Null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCorrectPassword(string inputId, string inputPwd)
        {
            if (accountDb.StringGet(inputId) == inputPwd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

