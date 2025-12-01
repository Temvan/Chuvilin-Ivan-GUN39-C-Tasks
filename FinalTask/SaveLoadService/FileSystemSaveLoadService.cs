using System.IO;

namespace SaveLoadService
{
    public class FileSystemSaveLoadService<T> : ISaveLoadService<T>
    {
        private readonly string _directoryPath;
   
        public FileSystemSaveLoadService(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void SaveData(T data, string id)
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            string filePath = Path.Combine(_directoryPath,id + ".txt");
            File.WriteAllText(filePath, data?.ToString()?? string.Empty);

        }
        public T LoadData(string id)
        {
            string filePath = Path.Combine(_directoryPath,id + ".txt");
            
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File with id {id} not found");
            }
            string content = File.ReadAllText(filePath);

            if (typeof(T) == typeof(string))
            {
                return (T)(object)content;
            }
            throw new InvalidDataException("Unsupported data type");
        }
    }
}