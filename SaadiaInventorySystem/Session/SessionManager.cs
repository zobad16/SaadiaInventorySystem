using System;
using System.Collections.Concurrent;

namespace SaadiaInventorySystem.Session
{
    public class SessionManager
    {
        private static SessionManager _instance;
        private static Object lockObj = new Object();
        private ConcurrentDictionary<string, SessionData> _sessions;

        #region Application contructor,singleton and managment  methods..

        private SessionManager()
        {
        }

        public static SessionManager GetInstance()
        {
            if (_instance == null)
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new SessionManager();
                        _instance._sessions = new ConcurrentDictionary<string, SessionData>();                        
                    }
                }
            }

            return _instance;
        }


        #endregion
        public void CreateSession(string token, SessionData data)
        {
            if (_sessions.ContainsKey(token))
            {
                throw new Exception("Error: Session already exists");
            }

            if (!_sessions.TryAdd(token, data))
            {
                throw new Exception("Error: Session creation failed");
            }

        }
        public SessionData SessionData(string token)
        {
            SessionData data;
            if (_sessions.TryGetValue(token, out data))
            {
                return data;
            }
            throw new Exception("Session not found");
        }

        public bool isUserSession(string userName)
        {

            foreach (var item in _sessions.Values)
            {
                if (userName.Equals(item.User.UserName))
                {
                    return true;
                }
            }

            return false;
        }
        public void RemoveSessionViaToken(string token)
        {
            //remove session
            _sessions.TryRemove(token, out SessionData data);            
        }

    }
}
