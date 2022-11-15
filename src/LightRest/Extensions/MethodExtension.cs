using System;
using System.Collections.Generic;
using System.Text;

namespace LightRest.Extensions;
internal static class MethodExtension
{
    internal static HttpMethod GetHttpMethod(this Method method)
    {
        return method switch
        {
            Method.OPTIONS => HttpMethod.Options,
            Method.GET => HttpMethod.Get,
            Method.POST => HttpMethod.Post,
            Method.PUT => HttpMethod.Put,
            Method.DELETE => HttpMethod.Delete,
            Method.TRACE => HttpMethod.Trace,

#if !NETSTANDARD2_0
            Method.PATCH => HttpMethod.Patch,
#endif
            _ => throw new ArgumentNullException($"Method {method} not found")
        };
    }
}
