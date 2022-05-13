using Microsoft.Extensions.Logging;
using NewsLetters.Domain.Entities;
using NewsLetters.Domain.Models;
using NewsLetters.Infrastructure.Data.Context;

namespace NewsLetters.Infrastructure.Data.Repository;

public class NewsRepository : BaseRepository<NewsEntity, AdvancedFilter>
{
    public NewsRepository(NewsLettersContext context, ILogger<BaseRepository<NewsEntity, AdvancedFilter>> logger) : base(context, logger)
    {
    }

    protected override IQueryable<NewsEntity> Where(IQueryable<NewsEntity> query, AdvancedFilter obj)
    {
        return query.Where(field => field.Author.Contains(obj.Search) ||
                                    field.Title.Contains(obj.Search) ||
                                    field.Category.Contains(obj.Search) ||
                                    field.Content.Contains(obj.Search) ||
                                    field.Date.ToString().Contains(obj.Search));
    }
}