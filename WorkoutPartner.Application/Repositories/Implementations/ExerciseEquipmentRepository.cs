using Microsoft.EntityFrameworkCore;
using WorkoutPartner.Application.Database;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Implementations;

public class ExerciseEquipmentRepository(DatabaseContext databaseContext) : IExerciseEquipmentRepository
{
    private readonly DbSet<ExerciseEquipment> _dbSet = databaseContext.Set<ExerciseEquipment>();

    public async Task AddAsync(ExerciseEquipment entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Remove(ExerciseEquipment entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await databaseContext.SaveChangesAsync() > -1;
    }
}