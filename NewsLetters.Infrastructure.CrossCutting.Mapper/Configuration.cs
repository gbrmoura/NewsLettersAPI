using Microsoft.Extensions.DependencyInjection;
using NewsLetters.Domain.Dtos;
using NewsLetters.Domain.Entities;
using NewsLetters.Infrastructure.CrossCutting.Mapper.Mappers;

namespace NewsLetters.Infrastructure.CrossCutting.Mapper;

public static class Configuration
{
    public static void AddMapper(this IServiceCollection services)
    {
        services.AddScoped<BaseMapper<NewsEntity, NewsDto>>();
        services.AddScoped<BaseMapper<UserEntity, UserDto>>();
    }
}