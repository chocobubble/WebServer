using System;
namespace WebServer.Service.Interface
{
	public interface ISessionService
	{
        public string CreateSessionId(string userId);
        public bool IsDuplicatedLogin(string sessionId);
        public bool IsValidSession(string sessionId);
        public bool IsValidSessionId(string sessionId);
        public bool RefreshSessionId(string sessionId);
        public bool DeleteSessionId(string sessionId);
        public string GetUserIdFromSessionId(string sessionId);
    }
}

