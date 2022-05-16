using System.Net;
using Microsoft.AspNetCore.Mvc;
using NewsLetters.Domain.Models;

namespace NewsLetters.Infrastructure.CrossCutting.Http.HttpResponse;

public static class SuccessResponse
{
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="defaultResponse"/>
    /// </summary>
    /// <param name="defaultResponse">Set the object <see cref="DefaultResponse"/></param>
    /// <returns></returns>
    public static IActionResult Ok(DefaultResponse defaultResponse)
        => new ObjectResult(defaultResponse) { StatusCode = (int)HttpStatusCode.OK };
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="message"/> and <paramref name="response"/> and <paramref name="error"/>
    /// </summary>
    /// <param name="message">Set the message on the <see cref="DefaultResponse"/> object</param>
    /// <param name="response">Set the response on the <see cref="DefaultResponse"/> object</param>
    /// <param name="error">Set the error on the <see cref="DefaultResponse"/> object</param>
    /// <returns></returns>
    public static IActionResult Ok(object message, object? response, object? error)
    {
        return new ObjectResult(new DefaultResponse()
        {
            Code = (int) HttpStatusCode.OK,
            Message = message,
            Error = error,
            Response = response
        }) { StatusCode = (int) HttpStatusCode.OK };
    }
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="defaultResponse"/>
    /// </summary>
    /// <param name="defaultResponse">Set the object <see cref="DefaultResponse"/></param>
    /// <returns></returns>
    public static IActionResult Created(DefaultResponse defaultResponse)
        => new ObjectResult(defaultResponse) { StatusCode = (int)HttpStatusCode.Created };
    
    /// <summary>
    /// Creates a <see cref="ObjectResult"/> object by specifying a <paramref name="message"/> and <paramref name="response"/> and <paramref name="error"/>
    /// </summary>
    /// <param name="message">Set the message on the <see cref="DefaultResponse"/> object</param>
    /// <param name="response">Set the response on the <see cref="DefaultResponse"/> object</param>
    /// <param name="error">Set the error on the <see cref="DefaultResponse"/> object</param>
    /// <returns></returns>
    public static IActionResult Created(object message, object? response, object? error)
    {
        return new ObjectResult(new DefaultResponse()
        {
            Code = (int) HttpStatusCode.Created,
            Message = message,
            Error = error,
            Response = response
        }) { StatusCode = (int) HttpStatusCode.Created };
    }
}