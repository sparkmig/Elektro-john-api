using System.Text.Json;

namespace ElektroJohnAPI.Services;

public class JsonFileReader
{
    public static T? ReadFromFile<T>(string path)
    {
        string file = File.ReadAllText(path);
        T? obj = JsonSerializer.Deserialize<T>(file);
        return obj;
    }
}