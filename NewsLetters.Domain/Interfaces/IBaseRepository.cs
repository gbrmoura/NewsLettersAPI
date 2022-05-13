using NewsLetters.Domain.Entities;
using NewsLetters.Domain.Models;

namespace NewsLetters.Domain.Interfaces;

public interface IBaseRepository<TEntity, TFilter> where TEntity : BaseEntity
{
    public void Insert(TEntity obj);
    public void Update(TEntity obj);
    public void Delete(TEntity obj);
    public IEnumerable<TEntity> Select(TFilter obj);
    public TEntity? Select(int id);
}