using Microsoft.Extensions.Logging;
using NewsLetters.Domain.Entities;
using NewsLetters.Domain.Models;
using NewsLetters.Infrastructure.Data.Context;

namespace NewsLetters.Infrastructure.Data.Repository;

public class UserRepository : BaseRepository<UserEntity, AdvancedFilter>
{
    public UserRepository(NewsLettersContext context, ILogger<BaseRepository<UserEntity,AdvancedFilter>> logger) : base(context, logger)
    {
    }
    
    protected override IQueryable<UserEntity> Where(IQueryable<UserEntity> query, AdvancedFilter obj)
    {
        if (!string.IsNullOrEmpty(obj.Search))
        {
            return query.Where(field => field.Email.Contains(obj.Search) || 
                                        field.FirstName.Contains(obj.Search) || 
                                        field.LastName.Contains(obj.Search));
        }
        return query;
    }
    
    
    
}