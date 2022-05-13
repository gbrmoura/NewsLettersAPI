using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsLetters.Domain.Entities;
using NewsLetters.Domain.Interfaces;
using NewsLetters.Domain.Models;
using NewsLetters.Infrastructure.Data.Context;

namespace NewsLetters.Infrastructure.Data.Repository;

public abstract class BaseRepository<TEntity> : BaseRepository<TEntity, BasicFilter> where TEntity : BaseEntity
{
    public BaseRepository(NewsLettersContext context, ILogger<BaseRepository<TEntity, BasicFilter>> logger) : base(context, logger)
    {
    }

    protected override IQueryable<TEntity> Where(IQueryable<TEntity> query, BasicFilter obj)
    {
        return query;
    }
    
}

public abstract class BaseRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter> where TEntity : BaseEntity where TFilter : BasicFilter
{
    private readonly NewsLettersContext _context;
    private readonly ILogger<BaseRepository<TEntity, TFilter>> _logger;
    
    public BaseRepository(NewsLettersContext context, ILogger<BaseRepository<TEntity, TFilter>> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public void Insert(TEntity obj)
    {
        _logger.LogInformation("Entity {EntityName} inserted", obj.GetType().Name);
        obj.DateCreated = DateTime.UtcNow;
        _context.Set<TEntity>().Add(obj);
        _context.SaveChanges();
    }

    public void Update(TEntity obj)
    {
        _logger.LogInformation("Entity {EntityName} updated", obj.GetType().Name);
        obj.DateModified = DateTime.UtcNow;
        _context.Entry(obj).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(TEntity obj)
    {
        _logger.LogInformation("Entity {EntityName} deleted", obj.GetType().Name);
        obj.IsDeleted = true;
        _context.Entry(obj).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public IEnumerable<TEntity> Select(TFilter obj)
    {
        _logger.LogInformation("Entity {EntityName} select all", typeof(TEntity).Name);
        return Where(_context.Set<TEntity>().AsQueryable(), obj)
            .Where(field => field.IsDeleted == false)
            .Skip(obj.PageIndex * obj.PageSize)
            .Take(obj.PageSize)
            .ToList();
    }

    public TEntity? Select(int id)
    {
        _logger.LogInformation("Entity {EntityName} select by id {id}", typeof(TEntity).Name, id);
        return _context.Set<TEntity>().Find(id);
    }
    
    protected abstract IQueryable<TEntity> Where(IQueryable<TEntity> query, TFilter obj);
    
}
