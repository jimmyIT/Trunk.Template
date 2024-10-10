using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Template.Trunk.Data.Bases.Entities;
using Template.Trunk.Data.DbContexts;

namespace Template.Trunk.Data.Bases.Repositories;

public class BaseRepository<TEntity>
    : IBaseRepository<TEntity> where TEntity
    : class, IBaseEntity
{
    protected readonly ApplicationDbContext _dbContext;
    public BaseRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task CreateAsync(TEntity entity)
    => await _dbContext.Set<TEntity>()
                           .AddAsync(entity);

    public async Task UpdateAsync(TEntity entity)
        => await Task.Run(() =>
        {
            _dbContext.Set<TEntity>()
                          .Update(entity);
        });

    public async Task DeleteAsync(TEntity entity)
        => await Task.Run(() =>
        {
            _dbContext.Set<TEntity>()
                          .Remove(entity);
        });

    public async Task<IQueryable<TEntity>> FindAllAsync()
    => await Task.FromResult(_dbContext.Set<TEntity>()
                                           .AsNoTracking());

    public async Task<IQueryable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        => await Task.FromResult(_dbContext.Set<TEntity>()
                                               .Where(expression)
                                               .AsNoTracking());

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _dbContext.Set<TEntity>()
                               .AsNoTracking()
                               .ToListAsync();

    public async Task<TEntity?> GetByCodeAsync(string code)
        => await _dbContext.Set<TEntity>()
                               .FirstOrDefaultAsync(entity => entity.Code == code);

    public async Task<TEntity?> GetByIdAsync(int id)
        => await _dbContext.Set<TEntity>()
                               .FirstOrDefaultAsync(entity => entity.Id == id);
}
