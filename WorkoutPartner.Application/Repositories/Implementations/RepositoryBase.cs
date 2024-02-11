using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WorkoutPartner.Application.Database;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Implementations;

public abstract class RepositoryBase<TEntity>(DatabaseContext databaseContext)
    : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DatabaseContext DatabaseContext = databaseContext;

    public void Delete(TEntity? entity) 
    {
        if (entity is null)
        {
            return;
        }
        DatabaseContext.Set<TEntity>();
        DatabaseContext.Remove(entity);
    }

    /// <inheritdoc/>
    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        var baseEntities = entities.ToList();
        
        if (baseEntities.Count == 0)
        {
            return;
        }
        
        DatabaseContext.Set<TEntity>();
        DatabaseContext.RemoveRange(baseEntities);
    }
    
    /// <inheritdoc/>
    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        DatabaseContext.Set<TEntity>();
        var entity = await DatabaseContext.FindAsync<TEntity>(id);

        return entity;
    }

    /// <inheritdoc/>
    public void Update(TEntity entity)
    {
        DatabaseContext.Set<TEntity>();
        DatabaseContext.Update(entity);
    }
    
    /// <inheritdoc/>
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        var baseEntities = entities.ToList();
        
        if (baseEntities.Count == 0)
        {
            return;
        }
        
        DatabaseContext.Set<TEntity>();
        DatabaseContext.UpdateRange(baseEntities);
    }

    /// <inheritdoc/>
    public async Task<bool> ExecuteUpdateAsync(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls)
    {
        return await DatabaseContext.Set<TEntity>()
            .Where(predicate)
            .ExecuteUpdateAsync(setPropertyCalls) > -1;
    }
    
    /// <inheritdoc/>
    public async Task<bool> ExecuteDeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DatabaseContext.Set<TEntity>()
            .Where(predicate)
            .ExecuteDeleteAsync() > -1;
    }

    /// <inheritdoc/>
    public async Task AddAsync(TEntity entity)
    {
        DatabaseContext.Set<TEntity>();
        await DatabaseContext.AddAsync(entity);
    }
    
    /// <inheritdoc/>
    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        var baseEntities = entities.ToList();
        
        if (baseEntities.Count == 0)
        {
            return;
        }
        
        DatabaseContext.Set<TEntity>();
        await DatabaseContext.AddAsync(baseEntities);
    }

    /// <inheritdoc/>
    public async Task<bool> SaveChangesAsync()
    {
        DatabaseContext.Set<TEntity>();
        return await DatabaseContext.SaveChangesAsync() > -1;
    }
}