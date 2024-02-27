using Microsoft.EntityFrameworkCore;
using WorkoutPartner.Application.Database;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Implementations;

public class ExerciseSchemaWorkoutPlanSchemaRepository(DatabaseContext databaseContext)
 : IExerciseSchemaWorkoutPlanSchemaRepository
{
    private readonly DbSet<ExerciseSchemaWorkoutPlanSchema> _dbSet = databaseContext.Set<ExerciseSchemaWorkoutPlanSchema>();

    public async Task AddRangeAsync(IEnumerable<ExerciseSchemaWorkoutPlanSchema> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Remove(ExerciseSchemaWorkoutPlanSchema entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await databaseContext.SaveChangesAsync() > -1;
    }
}