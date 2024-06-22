using System.Net;

namespace Journey.Exception.ExceptionsBase;

public abstract class JourneyException(string message) : SystemException(message)
{
    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();
}