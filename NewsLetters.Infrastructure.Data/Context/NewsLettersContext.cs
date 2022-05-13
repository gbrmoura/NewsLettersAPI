using Microsoft.EntityFrameworkCore;
using NewsLetters.Domain.Entities;

namespace NewsLetters.Infrastructure.Data.Context;

public class NewsLettersContext : DbContext
{
    public NewsLettersContext(DbContextOptions<NewsLettersContext> options) : base(options)
    {
        
    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<NewsEntity> News { get; set; }
}