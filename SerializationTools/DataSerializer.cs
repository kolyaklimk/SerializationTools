using System.Text.Json;

namespace SerializationTools;

public static class DataSerializer
{
    public static string JsonSerialize(object data)
    {
        return JsonSerializer.Serialize(data);
    }
    public static T JsonDeserialize<T>(string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    public static void JsonSerializeAsync<T>(Stream utf8Json, T value)
    {
        JsonSerializer.SerializeAsync(utf8Json, value);
    }
    public static void JsonDeserializeAsync<T>(Stream utf8Json)
    {
        JsonSerializer.DeserializeAsync<T>(utf8Json);
    }
}
