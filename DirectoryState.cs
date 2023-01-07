namespace Lab_15_1
{
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    class DirectoryState : IObservable
    {
        IEnumerable<string> state;
        string path;
        List<IObserver> observers;
        public DirectoryState(string path)
        {
            observers = new();
            this.path = path;
            state = Directory.GetFiles(path);
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
        public void NotifyObservers()
        {
            Console.WriteLine("Notifying observers");
            foreach (IObserver o in observers)
            {
                o.Update(state);
            }
        }
        public async Task Refresh()
        {
            state = Directory.GetFiles(path);
        }

    }
}