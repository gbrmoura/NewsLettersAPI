using NewsLetters.Domain.Dtos;
using NewsLetters.Domain.Entities;

namespace NewsLetters.Domain.Interfaces;

public interface IBaseService<TEntity, TFilter> where TEntity : BaseDto where TFilter : FilterDto
{
    TEntity Add(TEntity obj);
    TEntity Update(TEntity obj);
    void Delete(TEntity obj);
    TEntity GetById(int id);
    IEnumerable<TEntity> GetAll(TFilter filter);
    
}