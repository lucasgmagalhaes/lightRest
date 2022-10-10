using System.Text.Json;

namespace LightRest;

public class Serializer
{
    public Func<object, Type, string> Serialize { get; set; }
    public Func<string, Type, object?> Deserialize { get; set; }

    public Serializer()
    {
        Serialize = (obj, type) => JsonSerializer.Serialize(obj, type);
        Deserialize = (obj, type) => JsonSerializer.Deserialize(obj, type);
    }
}
