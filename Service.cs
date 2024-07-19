namespace CasinoGame
{
    public interface ISaveLoadService<T>
    {
        void SaveData(T data, string identifier);
        T LoadData(string identifier);
    }

    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _basePath;

        public FileSystemSaveLoadService(string basePath)
        {
            _basePath = basePath;

            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public void SaveData(string data, string identifier)
        {
            string filePath = Path.Combine(_basePath, $"{identifier}.txt");

            try
            {
                File.WriteAllText(filePath, data);
                Console.WriteLine($"Data saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        public string LoadData(string identifier)
        {
            string filePath = Path.Combine(_basePath, $"{identifier}.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    Console.WriteLine($"File {filePath} is loaded");
                    return data;
                }
                else
                {
                    Console.WriteLine($"File {filePath} does not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to load the file: {ex.Message}");
                return null;
            }
        }
    }
}
