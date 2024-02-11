using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Interfaces;

public interface IExerciseEquipmentRepository
{
    Task AddAsync(ExerciseEquipment entity);
    void Remove(ExerciseEquipment entity);
    Task<bool> SaveChangesAsync();
}