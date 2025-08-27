namespace SimpleInventorySystem.Services;

using System.Text.Json;
using SimpleInventorySystem.Utils;
using System.Collections.Generic;
using SimpleInventorySystem.Interfaces;

public class FileService<T> : IFileService <T>
{
    private readonly string filePath;

    public FileService(string fileName = "data.json")
    {
        filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
    }

    public List<T> ReadFile()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Logger.LogWarning($"File {filePath} not found. Starting with empty list.");
                return new List<T>();
            }

            string json = File.ReadAllText(filePath);
            var items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            Logger.LogInfo($"Data read from {filePath} successfully.");
            return items;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to read the JSON file {filePath}: {ex.Message}");
            return new List<T>();
        }
    }

    public void WriteFile(List<T> items)
    {
        try
        {
            string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Logger.LogInfo($"Data written to {filePath} successfully.");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to write to the JSON file {filePath}: {ex.Message}");
        }
    }
}
