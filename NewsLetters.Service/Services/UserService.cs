using Microsoft.Extensions.Logging;
using NewsLetters.Domain.Dtos;
using NewsLetters.Domain.Entities;
using NewsLetters.Domain.Interfaces;
using NewsLetters.Domain.Models;
using NewsLetters.Infrastructure.CrossCutting.Mapper.Mappers;
using NewsLetters.Infrastructure.Data.Repository;

namespace NewsLetters.Service.Services;

public class UserService : IBaseService<UserDto, FilterDto>
{
    private readonly UserRepository _repository;
    private readonly ILogger<UserService> _logger;
    private readonly BaseMapper<UserEntity, UserDto> _mapper;
    
    public UserService(UserRepository repository, ILogger<UserService> logger, BaseMapper<UserEntity, UserDto> mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    
    public UserDto Add(UserDto obj)
    {
        _logger.LogInformation("Method Add called on {Service}", nameof(UserService));
        var user = _mapper.Map(obj);
        _repository.Insert(user);
        return _mapper.Map(user);
    }

    public UserDto Update(UserDto obj)
    {
        _logger.LogInformation("Method Update called on {Service}", nameof(UserService));
        var user = _mapper.Map(obj);
        _repository.Update(user);
        return _mapper.Map(user);
    }

    public void Delete(UserDto obj)
    {
        _logger.LogInformation("Method Delete called on {Service}", nameof(UserService));
        _repository.Delete(_mapper.Map(obj));
    }

    public UserDto GetById(int id)
    {
        _logger.LogInformation("Method GetById called on {Service}", nameof(UserService));
        return _mapper.Map(_repository.Select(id));
    }

    public IEnumerable<UserDto> GetAll(FilterDto filter)
    {
        _logger.LogInformation("Method GetAll called on {Service}", nameof(UserService));
        return _mapper.Map(_repository.Select(new AdvancedFilter()
        {
            PageIndex = filter.PageIndex,
            PageSize = filter.PageSize,
            Search = filter.Search
        }));
    }
}