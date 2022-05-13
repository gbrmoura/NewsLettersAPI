using Microsoft.AspNetCore.Mvc;
using NewsLetters.Domain.Dtos;
using NewsLetters.Domain.Entities;
using NewsLetters.Infrastructure.CrossCutting.Mapper.Interface;
using NewsLetters.Infrastructure.CrossCutting.Mapper.Mappers;

namespace NewsLetters.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly ILogger<NewsController> _logger;
    
    public NewsController(ILogger<NewsController> logger)
    {
        _logger = logger;
    }

}