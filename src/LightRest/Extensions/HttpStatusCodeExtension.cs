using System.Net;

namespace LightRest.Extensions;

public static class HttpStatusCodeExtension
{
    /// <summary>
    /// Defines if a <see cref="HttpStatusCode"/> is a Sucess value or not
    /// 
    /// <br></br>
    /// 
    /// For reference:
    /// 
    /// <br></br>
    /// 
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#information_responses">Informational responses (100 – 199)</see> <br></br>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#successful_responses">Successful responses (200 – 299)</see> <br></br>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#information_responses">Redirection messages (300 – 399)</see> <br></br>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#redirection_messages">Client error responses (400 – 499)</see> <br></br>
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#server_error_responses">Server error responses (500 – 599)</see> <br></br>
    /// </summary>
    /// <param name="httpStatus">Status code to be check</param>
    /// <returns></returns>
    public static bool IsSucess(this HttpStatusCode? httpStatus)
    {
        if (httpStatus is null)
        {
            return false;
        }

        var intCode = (int)httpStatus;
        return intCode >= 100 && intCode < 300;
    }
}
