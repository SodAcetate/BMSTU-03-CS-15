namespace Lab_15_3
{
    class Program
    {
        public static void Main()
        {
            SingleRandomizer singleRandomizer = SingleRandomizer.Instance();
            for (int i = 0 ; i < 10 ; i++)
            {
                Console.WriteLine(singleRandomizer.Next());
                Thread.Sleep(300);
            }
        }
    }
}