using System.Text.Json;

namespace LightRest;

internal static class JsonHelper
{
    internal static string Serialize<T>(in T val, JsonSerializerOptions? options)
    {
        if (val is string valString)
        {
            if (string.IsNullOrEmpty(valString))
            {
                return string.Empty;
            }
            else
            {
                return valString;
            }
        }
        return JsonSerializer.Serialize(val, options);
    }
}
