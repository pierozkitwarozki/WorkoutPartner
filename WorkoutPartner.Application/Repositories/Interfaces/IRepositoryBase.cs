using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    void Delete(TEntity? entity);
    void DeleteRange(IEnumerable<TEntity> entities);
    Task<TEntity?> GetByIdAsync(Guid id);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task<bool> SaveChangesAsync();

    /// <summary>
    /// Executes updates on entities given by predicate
    /// Changes apply immediately, without SaveChanges
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="setPropertyCalls"></param>
    /// <returns>True if success, false if fail</returns>
    Task<bool> ExecuteUpdateAsync(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls);

    /// <summary>
    /// Executes delete on entities given by predicate
    /// Changes apply immediately, without SaveChanges
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>True if success, false if fail</returns>
    Task<bool> ExecuteDeleteAsync(Expression<Func<TEntity, bool>> predicate);
}