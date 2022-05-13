using System.Net;
using Microsoft.AspNetCore.Mvc;
using NewsLetters.Domain.Dtos;
using NewsLetters.Domain.Entities;
using NewsLetters.Domain.Models;
using NewsLetters.Infrastructure.CrossCutting.Mapper.Mappers;
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
        
            if (_service.GetAll(new FilterDto() {PageSize = 10, PageIndex = 0, Search = userDto.Email}).Any())
            {
                http.Message = "User already exists";
                http.Code = (int) HttpStatusCode.BadRequest;
                return BadRequest(http);
            }
            
            var dto = _service.Add(userDto);
            
            http.Code = (int) HttpStatusCode.OK;
            http.Message = "Success";
            http.Response = dto;
            return StatusCode(http.Code, http);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error on {Controller} with the method POST: {ExceptionMessage}", nameof(UserController), ex.Message);
            http.Code = (int) HttpStatusCode.InternalServerError;
            http.Message = "Internal Server Error";
            http.Error = ex.Message;
            return StatusCode(http.Code, http);
        }
    }
    
    // [HttpPut]
    // public IActionResult Put([FromBody] UserDto userDto)
    // {
    //     var user = userDto.ToEntity();
    //     return Ok(user);
    // }
    
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
            var dto = _service.GetAll(filterDto);
            
            http.Code = (int) HttpStatusCode.OK;
            http.Message = "Success";
            http.Response = dto;
            return StatusCode(http.Code, http);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error on {Controller} with the method GET: {ExceptionMessage}", nameof(UserController), ex.Message);
            http.Code = (int) HttpStatusCode.InternalServerError;
            http.Message = "Internal Server Error";
            http.Error = ex.Message;
            return StatusCode(http.Code, http);
        }
    }
    
    
}