using System.Diagnostics;
using System.Runtime.Serialization;

namespace LightRest;

[Serializable]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class SerializationException : Exception
{
    public readonly string? Response;

    public SerializationException()
    {
    }

    public SerializationException(string? response, string? message) : base(message)
    {
        Response = response;
    }

    public SerializationException(string? message, string? response, Exception? innerException) : base(message, innerException)
    {
        Response = response;
    }

    protected SerializationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
    {

    }


    private string GetDebuggerDisplay()
    {
        return ToString();
    }

}
