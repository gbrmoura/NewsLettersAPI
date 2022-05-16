using System.Net;
using Microsoft.AspNetCore.Mvc;
using NewsLetters.Domain.Dtos;
using NewsLetters.Domain.Models;
using NewsLetters.Infrastructure.CrossCutting.Http.HttpResponse;
using NewsLetters.Service.Services;

namespace NewsLetters.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _service;
    public UserController(ILogger<UserController> logger, UserService service)
    {
        _logger = logger;
        _service = service;
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] UserDto userDto)
    {
        var http = new DefaultResponse();
        try
        {
            // TODO: validar se os campos estão certos
        
            if (_service.GetAll(new FilterDto() { PageSize = 10, PageIndex = 0, Search = userDto.Email }).Any())
            {
                return  ClientErrorResponse.BadRequest("User already exists", null, null);
            }
            
            var dto = _service.Add(userDto);
            return SuccessResponse.Ok("The user was created successfully", dto, null);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error on {Controller} with the method POST: {ExceptionMessage}", nameof(UserController), ex.Message);
            return ErrorResponse.InternalServerError("Internal Server Error", null, ex.Message);
        }
    }
    
    [HttpPut]
    public IActionResult Put([FromBody] UserDto userDto)
    {
        
        // TODO: validar se os campos estão certos
        
        var user = userDto.ToEntity();
        return Ok(user);
    }
    
    // [HttpDelete]
    // public IActionResult Delete([FromBody] UserDto userDto)
    // {
    //     var user = userDto.ToEntity();
    //     return Ok(user);
    // }
    
    // [HttpGet("{id}")]
    // public IActionResult Get(int id)
    // {
    //     return Ok(new UserDto());
    // }
    
    [HttpGet]
    public IActionResult Get([FromQuery] FilterDto filterDto)
    {
        var http = new DefaultResponse();
        try
        {
            var enumerable = _service.GetAll(filterDto);
            return SuccessResponse.Ok("Success", enumerable, null);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error on {Controller} with the method GET: {ExceptionMessage}", nameof(UserController), ex.Message);
            return ErrorResponse.InternalServerError("Internal Server Error", null, ex.Message);
            
        }
    }
    
    
}