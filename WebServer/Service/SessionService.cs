using System;
using WebServer.Model;
using WebServer.Service.Interface;

namespace WebServer.Service
{
	public class SessionService : ISessionService
	{
        private Dictionary<string, UserSession> _sessionIdToUserSession = new Dictionary<string, UserSession>();
        private Dictionary<string, UserSession> _UserIdToSessionId = new Dictionary<string, UserSession>();

        public SessionService()
		{
		}

        public string CreateSessionId(string userId)
        {
            UserSession userSession = new UserSession();
            userSession.SessionId = Guid.NewGuid().ToString();
            userSession.UserId = userId;
            userSession.ExpireTime = DateTime.Now.AddMinutes(60);

            // 중복 로그인 처리 
            if (_UserIdToSessionId.TryGetValue(userId, out UserSession loginUserSession))
            {
                loginUserSession.State = StateType.Duplicated;
                _UserIdToSessionId[userId] = userSession;
            }
            else
            {
                _UserIdToSessionId.Add(userId, userSession);
            }
            _sessionIdToUserSession.Add(userSession.SessionId, userSession);

            return userSession.SessionId;
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

        public bool IsDuplicatedLogin(string sessionId)
        {
            if (_sessionIdToUserSession.TryGetValue(sessionId, out UserSession userSession))
            {
                if (userSession.State == StateType.Duplicated)
                {
                    return true;
                }
            }

            return false; 
        }

        public bool IsValidSessionId(string sessionId)
        {
            if (!_sessionIdToUserSession.TryGetValue(sessionId, out UserSession userSession))
            {
                return false;
            }

            if (DateTime.Now > userSession.ExpireTime)
            {
                _sessionIdToUserSession.Remove(sessionId);
                _UserIdToSessionId.Remove(sessionId);
                return false;
            }

            return true;
        }

        public bool RefreshSessionId(string sessionId)
        {
            if (!_sessionIdToUserSession.TryGetValue(sessionId, out UserSession userSession))
            {
                return false;
            }

            if (DateTime.Now > userSession.ExpireTime)
            {
                _sessionIdToUserSession.Remove(sessionId);
                return false;
            }

            userSession.ExpireTime = DateTime.Now.AddMinutes(60);

            return true;
        }

        public bool DeleteSessionId(string sessionId)
        {
            if (!_sessionIdToUserSession.TryGetValue(sessionId, out UserSession userSession))
            {
                return false;
            }

            _UserIdToSessionId.Remove(userSession.UserId);
            _sessionIdToUserSession.Remove(sessionId);

            return true;
        }

        public string GetUserIdFromSessionId(string sessionId)
        {
            return _sessionIdToUserSession[sessionId].UserId;
        }
    }
}

