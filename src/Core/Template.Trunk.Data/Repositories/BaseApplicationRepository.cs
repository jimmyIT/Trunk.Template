using Template.Trunk.Data.Bases.Entities;
using Template.Trunk.Data.Bases.Repositories;
using Template.Trunk.Data.DbContexts;

namespace Template.Trunk.Data.Repositories;

public interface IBaseApplicationRepository<TEntity>
    : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
{
    Task SaveAsync();
}

public class BaseApplicationRepository<TEntity>
    : BaseRepository<TEntity>, IBaseApplicationRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    public BaseApplicationRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task SaveAsync()
        => await _dbContext.SaveChangesAsync();
}
