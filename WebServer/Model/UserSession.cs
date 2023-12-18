using System;
using ProtoBuf;

namespace WebServer.Model
{
	public class UserSession
	{
        public UserSession()
        {
            State = StateType.Valid;
        }
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime ExpireTime { get; set; }
        public StateType State { get; set; }
    }

    public enum StateType
    {
        None = 0,
        Valid = 1,
        Duplicated = 2,
    }
}

