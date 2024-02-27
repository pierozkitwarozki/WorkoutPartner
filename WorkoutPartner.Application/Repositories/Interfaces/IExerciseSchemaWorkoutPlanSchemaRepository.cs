using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Interfaces;

public interface IExerciseSchemaWorkoutPlanSchemaRepository
{
    Task AddRangeAsync(IEnumerable<ExerciseSchemaWorkoutPlanSchema> entities);
    void Remove(ExerciseSchemaWorkoutPlanSchema entity);
}