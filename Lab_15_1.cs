using System;

namespace Lab_15_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryState dState = new("/home/crimson/Desktop/CSharp/Testground/");
            DirectoryWatcher dWatcher1 = new("dWatcher1", dState);
            dState.NotifyObservers();
            DirectoryWatcher dWatcher2 = new("dWatcher2", dState);
            Console.WriteLine();
            dState.NotifyObservers();
            dWatcher1.Stop();
            Console.WriteLine();
            dState.NotifyObservers();
            dWatcher2.Stop();
            Console.WriteLine();
            dState.NotifyObservers();
        }
    }
}