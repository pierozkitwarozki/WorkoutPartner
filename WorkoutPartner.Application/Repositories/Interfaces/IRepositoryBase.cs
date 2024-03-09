using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.Queries.Paging;

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
    /// Get paged result, by given search predicate
    /// </summary>
    /// <param name="pageRequest">Page size and number</param>
    /// <param name="predicate">Search predicate</param>
    /// <returns>
    /// Tuple:
    /// Value1 - IQueryable with entities,
    /// Value2 - boolean value if there are more elements
    /// </returns>
    (IQueryable<TEntity>, bool) WherePaged(
        PageRequest pageRequest,
        Expression<Func<TEntity, bool>> predicate);

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