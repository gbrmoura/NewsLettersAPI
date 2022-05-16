using System.Net;
using Microsoft.AspNetCore.Mvc;
using NewsLetters.Domain.Models;

namespace NewsLetters.Infrastructure.CrossCutting.Http.HttpResponse;

public static class ErrorResponse
{
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="defaultResponse"/>
    /// that will return <see cref="HttpStatusCode.InternalServerError"/> result.
    /// </summary>
    /// <param name="defaultResponse">Set the object <see cref="DefaultResponse"/></param>
    /// <returns></returns>
    public static IActionResult InternalServerError(DefaultResponse defaultResponse)
        => new ObjectResult(defaultResponse) { StatusCode = (int)HttpStatusCode.InternalServerError };
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="message"/> and <paramref name="response"/> and <paramref name="error"/>
    /// that will return <see cref="HttpStatusCode.NotFound"/> result.
    /// </summary>
    /// <param name="message">Set the message on the <see cref="DefaultResponse"/> object</param>
    /// <param name="response">Set the response on the <see cref="DefaultResponse"/> object</param>
    /// <param name="error">Set the error on the <see cref="DefaultResponse"/> object</param>
    /// <returns></returns>
    public static IActionResult InternalServerError(object message, object? response, object? error)
    {
        return new ObjectResult(new DefaultResponse()
        {
            Code = (int) HttpStatusCode.InternalServerError,
            Message = message,
            Error = error,
            Response = response
        }) { StatusCode = (int) HttpStatusCode.InternalServerError };
    }
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="defaultResponse"/>
    /// that will return <see cref="HttpStatusCode.NotImplemented"/> result.
    /// </summary>
    /// <param name="defaultResponse">Set the object <see cref="DefaultResponse"/></param>
    /// <returns></returns>
    public static IActionResult NotImplemented(DefaultResponse defaultResponse)
        => new ObjectResult(defaultResponse) { StatusCode = (int)HttpStatusCode.NotImplemented };
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="message"/> and <paramref name="response"/> and <paramref name="error"/>
    /// that will return <see cref="HttpStatusCode.NotFound"/> result.
    /// </summary>
    /// <param name="message">Set the message on the <see cref="DefaultResponse"/> object</param>
    /// <param name="response">Set the response on the <see cref="DefaultResponse"/> object</param>
    /// <param name="error">Set the error on the <see cref="DefaultResponse"/> object</param>
    /// <returns></returns>
    public static IActionResult NotImplemented(object message, object? response, object? error)
    {
        return new ObjectResult(new DefaultResponse()
        {
            Code = (int) HttpStatusCode.NotImplemented,
            Message = message,
            Error = error,
            Response = response
        }) { StatusCode = (int) HttpStatusCode.NotImplemented };
    }
}