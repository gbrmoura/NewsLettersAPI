using Microsoft.Extensions.DependencyInjection;
using NewsLetters.Service.Services;

namespace NewsLetters.Service;

public static class Configuration
{
    public static void AddNewsLettersServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
    }
}