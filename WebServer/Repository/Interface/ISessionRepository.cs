using System;
namespace WebServer.Repository.Interface
{
	public interface ISessionRepository
	{
        public string CreateSessionId(string userId);
        public bool IsValidSession(string sessionId);
        public bool IsDuplicatedLogin(string userId);
        public bool IsValidSessionId(string sessionId);
        public bool RefreshSessionId(string sessionId);
        public bool DeleteSessionId(string sessionId);
        public string GetUserIdFromSessionId(string sessionId);
    }
}

