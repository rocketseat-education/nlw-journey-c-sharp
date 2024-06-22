using System.Net.Mail;
using Journey.Communication.Responses;
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
            var responseJson = new ResponseErrorsJson(journeyException.GetErrorMessages());
            context.Result = new NotFoundObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var list = new List<string> { "Unknown errors" };
            var responseJson = new ResponseErrorsJson(list);
            context.Result = new ObjectResult(responseJson);   
        }
    }
}