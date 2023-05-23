using System.Text.Json;
using System.Xml.Serialization;

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

    public static Task JsonSerializeAsync<T>(Stream utf8Json, T value)
    {
        return JsonSerializer.SerializeAsync(utf8Json, value);
    }
    public static ValueTask<T> JsonDeserializeAsync<T>(Stream utf8Json)
    {
        return JsonSerializer.DeserializeAsync<T>(utf8Json);
    }

    public static string XmlSerialize<T>(T data)
    {
        var serializer = new XmlSerializer(typeof(T));
        using(TextWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, data);
            return writer.ToString();
        }
    }
    public static T XmlDeserialize<T>(string xmlString)
    {
        var serializer = new XmlSerializer(typeof(T));
        using(var reader = new StringReader(xmlString))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
}
