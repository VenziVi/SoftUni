using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class Session
    {
        public const string SessionCookiesName = "MyWebServerSID";
        public const string SessionCurrentDateKey = "CurrentDate";
        public const string SessionUserKey = "AuthenticatedUserId";

        private Dictionary<string, string> data;

        public Session(string _id)
        {
            Guard.AgainstNull(_id, nameof(_id));

            Id = _id;

            data = new Dictionary<string, string>();
        }

        public string Id { get; set; }

        public string this[string key] 
        {
            get => data[key];
            set => data[key] = value;
        }

        public bool ContainsKey(string key)
            => data.ContainsKey(key);

        public void Clear()
            => data.Clear();
    }
}
