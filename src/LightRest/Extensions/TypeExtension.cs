namespace LightRest.Extensions;

internal static class TypeExtension
{
    internal static bool Is<T>(this Type type)
    {
        return type == typeof(T);
    }
}
