using Domain.Entitites;

namespace Infrastructure
{
    public class Session
    {
        private static Session _instance;
        private static readonly object _lock = new object();

        private Session() { }

        public static Session Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Session();
                    }
                    return _instance;   
                }
            }
        }

        public void Clear()
        {
            Id = null;
            UserName = null;
            UserRole = null;
        }

        public int? Id { get; set; } = null;
        public string? UserName { get; set; } = null;
        public string? UserRole { get; set; } = null;
    }
}
