namespace Lab_15_2
{
    class Program
    {
        public static void Main()
        {
            MyLogger logger = new("Logs/txtLog.txt", "Logs/jsonLog.json");
            List<Item> items = new();
            // Заполняем лист
            items = logger.Read().ToList<Item>();
            Console.WriteLine("Read list:");
            foreach (var entry in items)
            {
                Console.WriteLine($"{entry.Id}. {entry.Name} : {entry.Value}");
            }
            // Создаём новый айтем
            Item item = new();
            Console.WriteLine("\nCreating new Item\nEnter Name");
            item.Name = Console.ReadLine();
            Console.WriteLine("Enter Value");
            item.Value = Convert.ToInt32(Console.ReadLine());
            if (items.Count > 0) item.Id = items.Max(entry => entry.Id) + 1;
            else item.Id = 1;
            // Пишем айтем в json
            logger.Write(item);
            // Читаем логи
            Console.WriteLine("\ntxtLog:");
            foreach (var line in logger.ReadTxt())
            {
                Console.WriteLine(line);
            }

        }
    }
}