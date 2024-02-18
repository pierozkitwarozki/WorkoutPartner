using WorkoutPartner.Application.Database;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Implementations;

public class ExerciseSchemaRepository(DatabaseContext databaseContext) 
    : RepositoryBase<ExerciseSchema>(databaseContext), IExerciseSchemaRepository
{
    
}