namespace Lab_15_1
{
    interface IObserver
    {
        void Update(object ob);
        void Stop();
    }
    class DirectoryWatcher : IObserver
    {
        public string Name { get; set; }
        IObservable Dir;
        public DirectoryWatcher(string name, IObservable dir)
        {
            Name = name;
            Dir = dir;
            Dir.AddObserver(this);
        }
        public void Update(object ob)
        {
            Console.WriteLine($"{Name}:");
            foreach (var item in (IEnumerable<string>)ob)
            {
                Console.WriteLine(item);
            }
        }
        public void Stop()
        {
            Dir.RemoveObserver(this);
            Dir = null;
        }
    }
}