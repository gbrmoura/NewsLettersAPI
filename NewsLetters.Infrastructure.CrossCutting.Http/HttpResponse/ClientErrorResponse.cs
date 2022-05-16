using System.Net;
using Microsoft.AspNetCore.Mvc;
using NewsLetters.Domain.Models;

namespace NewsLetters.Infrastructure.CrossCutting.Http.HttpResponse;

public static class ClientErrorResponse
{
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="defaultResponse"/>
    /// that will return <see cref="HttpStatusCode.BadRequest"/> result.
    /// </summary>
    /// <param name="defaultResponse">Set the object <see cref="DefaultResponse"/></param>
    /// <returns></returns>
    public static IActionResult BadRequest(DefaultResponse defaultResponse) 
        => new ObjectResult(defaultResponse) { StatusCode = (int)HttpStatusCode.BadRequest };

    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="message"/> and <paramref name="response"/> and <paramref name="error"/>
    /// that will return <see cref="HttpStatusCode.BadRequest"/> result.
    /// </summary>
    /// <param name="message">Set the message on the <see cref="DefaultResponse"/> object</param>
    /// <param name="response">Set the response on the <see cref="DefaultResponse"/> object</param>
    /// <param name="error">Set the error on the <see cref="DefaultResponse"/> object</param>
    /// <returns></returns>
    public static IActionResult BadRequest(object message, object? response, object? error)
    {
        return new ObjectResult(new DefaultResponse()
        {
            Code = (int) HttpStatusCode.BadRequest,
            Message = message,
            Error = error,
            Response = response
        }) { StatusCode = (int) HttpStatusCode.BadRequest };
    }
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="defaultResponse"/>
    /// that will return <see cref="HttpStatusCode.Unauthorized"/> result.
    /// </summary>
    /// <param name="defaultResponse">Set the object <see cref="DefaultResponse"/></param>
    /// <returns></returns>
    public static IActionResult Unauthorized(DefaultResponse defaultResponse)
        => new ObjectResult(defaultResponse) { StatusCode = (int)HttpStatusCode.Unauthorized };
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="message"/> and <paramref name="response"/> and <paramref name="error"/>
    /// that will return <see cref="HttpStatusCode.Unauthorized"/> result.
    /// </summary>
    /// <param name="message">Set the message on the <see cref="DefaultResponse"/> object</param>
    /// <param name="response">Set the response on the <see cref="DefaultResponse"/> object</param>
    /// <param name="error">Set the error on the <see cref="DefaultResponse"/> object</param>
    /// <returns></returns>
    public static IActionResult Unauthorized(object message, object? response, object? error)
    {
        return new ObjectResult(new DefaultResponse()
        {
            Code = (int) HttpStatusCode.Unauthorized,
            Message = message,
            Error = error,
            Response = response
        }) { StatusCode = (int) HttpStatusCode.Unauthorized };
    }
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="defaultResponse"/>
    /// that will return <see cref="HttpStatusCode.NotFound"/> result.
    /// </summary>
    /// <param name="defaultResponse">Set the object <see cref="DefaultResponse"/></param>
    /// <returns></returns>
    public static IActionResult NotFound(DefaultResponse defaultResponse)
        => new ObjectResult(defaultResponse) { StatusCode = (int)HttpStatusCode.NotFound };
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="message"/> and <paramref name="response"/> and <paramref name="error"/>
    /// that will return <see cref="HttpStatusCode.NotFound"/> result.
    /// </summary>
    /// <param name="message">Set the message on the <see cref="DefaultResponse"/> object</param>
    /// <param name="response">Set the response on the <see cref="DefaultResponse"/> object</param>
    /// <param name="error">Set the error on the <see cref="DefaultResponse"/> object</param>
    /// <returns></returns>
    public static IActionResult NotFound(object message, object? response, object? error)
    {
        return new ObjectResult(new DefaultResponse()
        {
            Code = (int) HttpStatusCode.NotFound,
            Message = message,
            Error = error,
            Response = response
        }) { StatusCode = (int) HttpStatusCode.NotFound };
    }
}