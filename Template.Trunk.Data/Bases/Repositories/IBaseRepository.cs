using System.Linq.Expressions;
using Template.Trunk.Data.Bases.Entities;

namespace Template.Trunk.Data.Bases.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
{
    Task<IQueryable<TEntity>> FindAllAsync();
    Task<IQueryable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity?> GetByCodeAsync(string code);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
