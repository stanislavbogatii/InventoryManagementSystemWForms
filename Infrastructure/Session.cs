using Domain.Interfaces;

namespace Infrastructure
{
    public class Session : IObservable
    {
        private static Session _instance;
        private static readonly object _lock = new object();
        private readonly List<IObserver> _observers = new List<IObserver>();

        private int? _id = null;
        private string? _userName = null;
        private string? _userRole = null;

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
            Notify();
        }

        public int? Id 
        { 
            get => _id; 
            set
            {
                _id = value;
                Notify();
            }
        }

        public string? UserName 
        { 
            get => _userName; 
            set
            {
                _userName = value;
                Notify();
            }
        }

        public string? UserRole 
        { 
            get => _userRole; 
            set
            {
                _userRole = value;
                Notify();
            }
        }


        public void Attach(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
