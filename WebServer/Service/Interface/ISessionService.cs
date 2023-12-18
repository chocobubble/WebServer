using System;
namespace WebServer.Service.Interface
{
	public interface ISessionService
	{
        public string CreateSessionId(string userId);

        public bool IsValidSession(string sessionId);

        public bool IsValidSessionId(string sessionId);

        public bool RefreshSessionId(string sessionId);

        public bool DeleteSessionId(string sessionId);
    }
}

