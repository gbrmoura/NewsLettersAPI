using Microsoft.AspNetCore.Mvc;
using NewsLetters.Domain.Dtos;
using NewsLetters.Domain.Entities;
using NewsLetters.Infrastructure.CrossCutting.Mapper.Mappers;

namespace NewsLetters.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    
}