using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsLetters.Domain.Interfaces;
using NewsLetters.Infrastructure.Data.Context;
using NewsLetters.Infrastructure.Data.Repository;

namespace NewsLetters.Infrastructure.Data;

public static class Configuration
{
    public static void AddMySqlConnection(this IServiceCollection services)
    {
        const string connectionString = "Server=localhost;Database=newsletters;Uid=root;Pwd=;";
        services.AddDbContext<NewsLettersContext>(ops =>
        {
            ops.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<UserRepository>();
        services.AddScoped<NewsRepository>();
    }
}