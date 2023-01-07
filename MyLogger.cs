using System.Text.Json;

namespace Lab_15_2
{
    interface IRepository<T>
    {
        IEnumerable<T> Read();
        void Write(T entry);
    }
    class MyLogger : IRepository<Item>
    {
        string txtLogPath;
        string jsonLogPath;
        public MyLogger(string txtPath, string jsonPath){
            txtLogPath = txtPath;
            jsonLogPath = jsonPath;
        }
        public IEnumerable<Item> Read()
        {
            List<Item> result = new();
            using (FileStream jsonStream = File.Open(jsonLogPath, FileMode.Open, FileAccess.Read)){
                using (StreamReader jsonReader = new(jsonStream))
                {
                    while(!jsonReader.EndOfStream)
                    {
                        result.Add(JsonSerializer.Deserialize<Item>(jsonReader.ReadLine()));
                    }
                }
            }
            return result;
        }
        public IEnumerable<string> ReadTxt()
        {
            List<string> result = new();
            using (FileStream txtStream = File.Open(txtLogPath, FileMode.Open, FileAccess.Read)){
                using(StreamReader txtReader = new(txtStream))
                {
                    while(!txtReader.EndOfStream)
                    {
                        result.Add(txtReader.ReadLine());
                    }
                }
            }
            return result;
        }
        public void Write(Item entry){
            using (FileStream txtStream = File.Open(txtLogPath, FileMode.Append, FileAccess.Write)){
                using (StreamWriter txtWriter = new(txtStream))
                {
                    txtWriter.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} : Added entry [{entry.Name} | id {entry.Id}]");
                }
            }
            using (FileStream jsonStream = File.Open(jsonLogPath, FileMode.Append, FileAccess.Write)){
                using (StreamWriter jsonWriter = new(jsonStream))
                {
                    jsonWriter.WriteLine(JsonSerializer.Serialize(entry));
                }
            }
        }

    }
}