using System.Net;

namespace Journey.Exception.ExceptionsBase;
public class ErrorOnValidateException : JourneyException
{
    private readonly IList<string> _errors;
    public ErrorOnValidateException(IList<string> messages) : base(string.Empty)
    {
        _errors = messages;
    }

    public override IList<string> GetErrorMessage()
    {
       return _errors;
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }
}

