using System;
using System.IO;
using System.Text.Json;

namespace FinalTask.SaveLoad
{
    public sealed class FileSystemSaveLoadService<T> : ISaveLoadService<T>
    {
        private readonly string _basePath;

        public FileSystemSaveLoadService(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Base path cannot be null or empty.", nameof(basePath));

            _basePath = basePath;

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
        }

        public void SaveData(T data, string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var path = BuildPath(id);

            try
            {
                var json = JsonSerializer.Serialize(data);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while saving data with id '{id}' to path '{path}'", ex);
            }
        }

        public T LoadData(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var path = BuildPath(id);

            if (!File.Exists(path))
                throw new FileNotFoundException($"Save file not found for id '{id}'", path);

            try
            {
                var json = File.ReadAllText(path);
                var obj = JsonSerializer.Deserialize<T>(json);
                if (obj == null)
                    throw new Exception($"Failed to deserialize data for id '{id}' from path '{path}'");

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while loading data with id '{id}' from path '{path}'", ex);
            }
        }

        private string BuildPath(string id)
        {
            return Path.Combine(_basePath, id + ".txt");
        }
    }
}
