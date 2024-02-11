using WorkoutPartner.Application.Database;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Repositories.Implementations;

public class EquipmentRepository(DatabaseContext databaseContext) 
    : RepositoryBase<Equipment>(databaseContext), IEquipmentRepository
{
    
}