using System;
using WebServer.Model;
using WebServer.Repository.Interface;
using WebServer.Service.Interface;

namespace WebServer.Service
{
	public class SessionService : ISessionService
	{
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
		{
            _sessionRepository = sessionRepository;
		}

        public string CreateSessionId(string userId)
        {
            string sessionId = _sessionRepository.CreateSessionId(userId);
            return sessionId;
        }

        public bool IsValidSession(string sessionId)
        {
            if (!IsValidSessionId(sessionId))
            {
                return false;
            }
            RefreshSessionId(sessionId);
            return true;
        }

        public bool IsDuplicatedLogin(string userId)
        {
            return _sessionRepository.IsDuplicatedLogin(userId); 
        }

        public bool IsValidSessionId(string sessionId)
        {
            return _sessionRepository.IsValidSessionId(sessionId);
        }

        public bool RefreshSessionId(string sessionId)
        {
            return _sessionRepository.RefreshSessionId(sessionId);
        }

        public bool DeleteSessionId(string sessionId)
        {
            return _sessionRepository.DeleteSessionId(sessionId);
        }

        public string GetUserIdFromSessionId(string sessionId)
        {
            return _sessionRepository.GetUserIdFromSessionId(sessionId);
        }
    }
}

