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
        // 1. 세션 생성
        // 2. 세션이 유효한지 확인
        // 3. 세션을 연장

        // 로그인 할 때, 세션을 만들어줌
        // 세션은 어떤 유저의 세션인지 알 수 있어야 됨
        // 세션을 사용하면 동접 지표를 대략적으로 알 수 있음
        public string CreateSessionId(string userId)
        {
            if (_UserIdToSessionId.TryGetValue(userId, out _))
            {
                // 어? 너 이미 로그인한 상태인데?
                // 중복 로그인 처리
                // 이전의 세션 상태를 중복 로그인으로 변경
            }
            UserSession userSession = new UserSession();
            userSession.SessionId = Guid.NewGuid().ToString();
            userSession.UserId = userId;
            userSession.ExpireTime = DateTime.Now.AddMinutes(3);

            _sessionIdToUserSession.Add(userSession.SessionId, userSession);
            _UserIdToSessionId.Add(userId, userSession);
            return userSession.SessionId;
        }

        public bool IsValidSessionId(string sessionId)
        {
            if (!_sessionIdToUserSession.TryGetValue(sessionId, out UserSession userSession))
            {
                return false;
            }

            // State를 체크해서 중복 로그인이면 기존에 접속 했던 유저에게 중복 로그인이란느 것을 알려줌

            if (DateTime.Now > userSession.ExpireTime)
            {
                _sessionIdToUserSession.Remove(sessionId);
                _UserIdToSessionId.Remove(sessionId);
                return false;
            }

            return true;
        }

        public bool KeepAliveSessionId(string sessionId)
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

            userSession.ExpireTime = DateTime.Now.AddMinutes(3);
            return true;
        }

        public bool DeleteSessionId(string sessionId)
        {
            if (!_sessionIdToUserSession.TryGetValue(sessionId, out _))
            {
                return false;
            }

            _sessionIdToUserSession.Remove(sessionId);
            return true;
        }
    }
}

