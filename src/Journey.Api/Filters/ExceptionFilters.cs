using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is JourneyException)
        {
            var journeyException = (JourneyException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)journeyException.GetStatusCode();

            var reposnseJson = new ResponseErrorsJson(journeyException.GetErrorMessage());

            context.Result = new ObjectResult(reposnseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var responseJson = new ResponseErrorsJson(new List<string> {ResourceErrorMessages.ERRO_DESCONHECIDO});

            context.Result = new ObjectResult(responseJson);
        }
    }
}