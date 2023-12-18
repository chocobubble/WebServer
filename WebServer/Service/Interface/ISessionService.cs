using System;
namespace WebServer.Service.Interface
{
	public interface ISessionService
	{
        public string CreateSessionId(string userId);

        public bool IsValidSessionId(string sessionId);

        public bool KeepAliveSessionId(string sessionId);

        public bool DeleteSessionId(string sessionId);
    }
}

