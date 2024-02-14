using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WorkoutPartner.Application.Database;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.Paging;

namespace WorkoutPartner.Application.Repositories.Implementations;

public abstract class RepositoryBase<TEntity>(DatabaseContext databaseContext) 
    : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> DbSet = databaseContext.Set<TEntity>();

    public void Delete(TEntity? entity) 
    {
        if (entity is null)
        {
            return;
        }
        DbSet.Remove(entity);
    }

    /// <inheritdoc/>
    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        var baseEntities = entities.ToList();
        
        if (baseEntities.Count == 0)
        {
            return;
        }
        
        DbSet.RemoveRange(baseEntities);
    }
    
    /// <inheritdoc/>
    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var entity = await DbSet.FindAsync(id);

        return entity;
    }

    /// <inheritdoc/>
    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }
    
    /// <inheritdoc/>
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        var baseEntities = entities.ToList();
        
        if (baseEntities.Count == 0)
        {
            return;
        }
        
        DbSet.UpdateRange(baseEntities);
    }

    /// <inheritdoc/>
    public (IQueryable<TEntity>, bool) WherePaged(PageRequest pageRequest, Expression<Func<TEntity, bool>> predicate)
    {
        var queryable = DbSet
            .Where(predicate)
            .OrderBy(x => x.CreatedAt)
            .Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize)
            .Take(pageRequest.PageSize);

        var moreExists = queryable.Count() >= pageRequest.PageSize;

        return (queryable, moreExists);
    }

    /// <inheritdoc/>
    public async Task<bool> ExecuteUpdateAsync(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls)
    {
        return await DbSet
            .Where(predicate)
            .ExecuteUpdateAsync(setPropertyCalls) > -1;
    }
    
    /// <inheritdoc/>
    public async Task<bool> ExecuteDeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet
            .Where(predicate)
            .ExecuteDeleteAsync() > -1;
    }

    /// <inheritdoc/>
    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }
    
    /// <inheritdoc/>
    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        var baseEntities = entities.ToList();
        
        if (baseEntities.Count == 0)
        {
            return;
        }
        
        await DbSet.AddRangeAsync(baseEntities);
    }

    /// <inheritdoc/>
    public async Task<bool> SaveChangesAsync()
    {
        return await databaseContext.SaveChangesAsync() > -1;
    }
}