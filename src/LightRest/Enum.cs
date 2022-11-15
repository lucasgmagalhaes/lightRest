namespace LightRest;

public enum Method
{
    GET,
    POST,
    PUT,
    DELETE,
    HEAD,
    TRACE,
    OPTIONS,

#if !NETSTANDARD2_0
    PATCH
#endif
}
